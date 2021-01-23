    using UnityEngine;
    using System.Collections;
    using System.Net;
    using System.Net.Sockets;
    public class TCPServer : MonoBehaviour 
    {
    public enum TestMessageOrder
    {
        NotConnected,
        Connected,
        SendFirstMessage,
        ReceiveFirstMessageReply,
        SendSecondMessage,
        ReceiveSecondMessageReply,
        SendThirdMessage,
        ReceiveThirdMessageReply,
        Error,
        Done
    }
    protected TcpListener m_tcpListener;
    protected Socket m_testClientSocket;
    protected byte[] m_readBuffer;
    [SerializeField]
    protected TestMessageOrder m_testClientState;
    public void StartServer()
    {
        m_tcpListener = new TcpListener(IPAddress.Any, 10000);
        m_tcpListener.Start();
        StartListeningForConnections();
    }
    void StartListeningForConnections()
    {
        m_tcpListener.BeginAcceptSocket(AcceptNewSocket, m_tcpListener);
        Debug.Log("SERVER ACCEPTING NEW CLIENTS");
    }
    void AcceptNewSocket(System.IAsyncResult iar)
    {
        m_testClientSocket = null;
        m_testClientState = TestMessageOrder.NotConnected;
        m_readBuffer = new byte[1024];
        try
        {
            m_testClientSocket = m_tcpListener.EndAcceptSocket(iar);
        }
        catch (System.Exception ex)
        {
            //Debug.LogError(string.Format("Exception on new socket: {0}", ex.Message));
        }
        m_testClientSocket.NoDelay = true;
        m_testClientState = TestMessageOrder.Connected;
        BeginReceiveData();
        SendTestData();
        StartListeningForConnections();
    }
    void SendTestData()
    {
        Debug.Log(string.Format("Server: Client state: {0}", m_testClientState));
        switch (m_testClientState)
        {
            case TestMessageOrder.Connected:
                SendMessageOne();
                break;
            //case TestMessageOrder.SendFirstMessage:
                //break;
            case TestMessageOrder.ReceiveFirstMessageReply:
                SendMessageTwo();
                break;
            //case TestMessageOrder.SendSecondMessage:
                //break;
            case TestMessageOrder.ReceiveSecondMessageReply:
                SendMessageTwo();
                break;
            case TestMessageOrder.SendThirdMessage:
                break;
            case TestMessageOrder.ReceiveThirdMessageReply:
                m_testClientState = TestMessageOrder.Done;
                Debug.Log("ALL DONE");
                break;
            case TestMessageOrder.Done:
                break;
            default:
                Debug.LogError("Server shouldn't be here");
                break;
        }
    }
    void SendMessageOne()
    {
        m_testClientState = TestMessageOrder.SendFirstMessage;
        byte[] newMsg = new byte[] { 1, 100, 101, 102, 103, 104 };
        SendMessage(newMsg);
    }
    void SendMessageTwo()
    {
        m_testClientState = TestMessageOrder.SendSecondMessage;
        byte[] newMsg = new byte[] { 3, 100, 101, 102, 103, 104, 105, 106 };
        SendMessage(newMsg);
    }
    void SendMessageThree()
    {
        m_testClientState = TestMessageOrder.SendThirdMessage;
        byte[] newMsg = new byte[] { 5, 100, 101, 102, 103, 104, 105, 106, 107, 108 };
        SendMessage(newMsg);
    }
    void SendMessage(byte[] msg)
    {
        string temp = TCPServer.CompileBytesIntoString(msg);
        Debug.Log(string.Format("Server sending: '{0}'", temp));
        m_testClientSocket.BeginSend(msg, 0, msg.Length, SocketFlags.None, EndSend, msg);
    }
    void EndSend(System.IAsyncResult iar)
    {
        m_testClientSocket.EndSend(iar);
        byte[] msgSent = (iar.AsyncState as byte[]);
        string temp = CompileBytesIntoString(msgSent);
        Debug.Log(string.Format("Server sent: '{0}'", temp));
    }
    void BeginReceiveData()
    {
        m_testClientSocket.BeginReceive(m_readBuffer, 0, m_readBuffer.Length, SocketFlags.None, EndReceiveData, null);
    }
    void EndReceiveData(System.IAsyncResult iar)
    {
        int numBytesReceived = m_testClientSocket.EndReceive(iar);
        ProcessData(numBytesReceived);
        BeginReceiveData();
    }
    void ProcessData(int numBytesRecv)
    {
        string temp = TCPServer.CompileBytesIntoString(m_readBuffer, numBytesRecv);
        Debug.Log(string.Format("Server recv: '{0}'", temp));
        byte firstByte = m_readBuffer[0];
        switch (firstByte)
        {
            case 1:
                Debug.LogError(string.Format("Server should not receive first byte of 1"));
                m_testClientState = TestMessageOrder.Error;
                break;
            case 2:
                m_testClientState = TestMessageOrder.ReceiveSecondMessageReply;
                break;
            case 3:
                Debug.LogError(string.Format("Server should not receive first byte of 3"));
                m_testClientState = TestMessageOrder.Error;
                break;
            case 4:
                m_testClientState = TestMessageOrder.ReceiveThirdMessageReply;
                break;
            case 5:
                Debug.LogError(string.Format("Server should not receive first byte of 5"));
                m_testClientState = TestMessageOrder.Error;
                break;
            default:
                Debug.LogError(string.Format("Server should not receive first byte of {0}", firstByte));
                m_testClientState = TestMessageOrder.Error;
                break;
        }
        SendTestData();
    }
    void OnDestroy()
    {
        if (m_testClientSocket != null)
        {
            m_testClientSocket.Close();
            m_testClientSocket = null;
        }
        if (m_tcpListener != null)
        {
            m_tcpListener.Stop();
            m_tcpListener = null;
        }
    }
    public static string CompileBytesIntoString(byte[] msg, int len = -1)
    {
        string temp = "";
        int count = len;
        if (count < 1)
        {
            count = msg.Length;
        }
        for (int i = 0; i < count; i++)
        {
            temp += string.Format("{0} ", msg[i]);
        }
        return temp;
    }
    }
