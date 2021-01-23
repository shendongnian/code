    using UnityEngine;
    using System.Collections;
    using System.Net;
    using System.Net.Sockets;
    public class TCPClient : MonoBehaviour {
    public ConnectGUI.ConnectionState connectState;
    Socket m_clientSocket;
    byte[] m_readBuffer;
    void Start()
    {
        connectState = ConnectGUI.ConnectionState.NotConnected;
        m_readBuffer = new byte[1024];
    }
    public void StartConnect()
    {
        m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
           System.IAsyncResult result = m_clientSocket.BeginConnect("127.0.0.1", 10000, EndConnect, null);
           bool connectSuccess = result.AsyncWaitHandle.WaitOne(System.TimeSpan.FromSeconds(10));
           if (!connectSuccess)
           {
               m_clientSocket.Close();
               Debug.LogError(string.Format("Client unable to connect. Failed"));
           }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(string.Format("Client exception on beginconnect: {0}", ex.Message));
        }
        connectState = ConnectGUI.ConnectionState.AttemptingConnect;
    }
    void EndConnect(System.IAsyncResult iar)
    {
        m_clientSocket.EndConnect(iar);
        m_clientSocket.NoDelay = true;
        connectState = ConnectGUI.ConnectionState.Connected;
        BeginReceiveData();
        Debug.Log("Client connected");
    }
    void OnDestroy()
    {
        if (m_clientSocket != null)
        {
            m_clientSocket.Close();
            m_clientSocket = null;
        }
    }
    void BeginReceiveData()
    {
        m_clientSocket.BeginReceive(m_readBuffer, 0, m_readBuffer.Length, SocketFlags.None, EndReceiveData, null);
    }
    void EndReceiveData(System.IAsyncResult iar)
    {
        int numBytesReceived = m_clientSocket.EndReceive(iar);
        ProcessData(numBytesReceived);
        BeginReceiveData();
    }
    void ProcessData(int numBytesRecv)
    {
        string temp = TCPServer.CompileBytesIntoString(m_readBuffer, numBytesRecv);
        
        Debug.Log(string.Format("Client recv: '{0}'", temp));
        byte[] replyMsg = new byte[m_readBuffer.Length];
        System.Buffer.BlockCopy(m_readBuffer, 0, replyMsg, 0, numBytesRecv);
        
        //Increment first byte and send it back
        replyMsg[0] = (byte)((int)replyMsg[0] + 1);
        
        SendReply(replyMsg, numBytesRecv);
    }
    void SendReply(byte[] msgArray, int len)
    {
        string temp = TCPServer.CompileBytesIntoString(msgArray, len);
        Debug.Log(string.Format("Client sending: len: {1} '{0}'", temp, len));
        m_clientSocket.BeginSend(msgArray, 0, len, SocketFlags.None, EndSend, msgArray);
    }
    void EndSend(System.IAsyncResult iar)
    {
        m_clientSocket.EndSend(iar);
        byte[] msg = (iar.AsyncState as byte[]);
        string temp = TCPServer.CompileBytesIntoString(msg, msg.Length);
        Debug.Log(string.Format("Client sent: '{0}'", temp));
        System.Array.Clear(msg, 0, msg.Length);
        msg = null;
    }
    }
