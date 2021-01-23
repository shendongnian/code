    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Sockets;
    using System.Net;
    using System.Windows.Forms;
    namespace AsyncServer
    {
        class Server
        {
            private int port;
            private Socket serverSocket;
            private List<StateObject> clientList;
            private const int DEFAULT_PORT = 1338;
            public AsyncServer parent;
            public Server()
            {
                this.port = 1338; //default port
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientList = new List<StateObject>();
            }
            public Server(int port)
            {
                this.port = port;
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientList = new List<StateObject>();
            }
            public void startListening(int port = DEFAULT_PORT)
            {
                this.port = port;
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, this.port));
                serverSocket.Listen(1);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            private void AcceptCallback(IAsyncResult AR)
            {
                try
                {
                    StateObject state = new StateObject();
                    state.workSocket = serverSocket.EndAccept(AR);
                    clientList.Add(state);
                    state.workSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
                    serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
                }
                catch { }
            }
            private void ReceiveCallback(IAsyncResult AR)
            {
                StateObject state = (StateObject)AR.AsyncState;
                Socket s = state.workSocket;
                int received = 0;
                received = s.EndReceive(AR);
                if (received == 0)
                {
                    clientList.Remove(state);
                    foreach (StateObject others in clientList)
                        others.workSocket.Send(Encoding.ASCII.GetBytes("Client disconnected " + s.LocalEndPoint));
                    return;
                }
                if (received > 0)
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, received));
                string content = state.sb.ToString();
                if(content.Contains("\n") && content.Length > 1)
                {
                    if (parent != null)
                        parent.Invoke((MethodInvoker)delegate() { parent.console.Text += content; });
                    foreach (StateObject others in clientList)
                        if (others != state)
                            others.workSocket.Send(Encoding.ASCII.GetBytes(content.ToCharArray()));
                    state.sb.Clear();
                }
                Array.Clear(state.buffer, 0, StateObject.BufferSize);
                s.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
        }
        class StateObject
        {
            public Socket workSocket = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }
    }
