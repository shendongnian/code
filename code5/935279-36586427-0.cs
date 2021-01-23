    class Server
    {
        private static int bufferSize = 2048;
        private static byte[] buffer = new byte[bufferSize];
        private static List<Socket> clientSockets = new List<Socket>();
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Console.Title = "Server";
            SetupServer();
            Console.ReadKey();
            CloseAllSockets();
        }
        private static void SetupServer()
        {
            Console.WriteLine("Settings Up Server Plz Wait");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 69));
            serverSocket.Listen(10);
            serverSocket.BeginAccept(new AsyncCallback(CallBack), null);
            Console.WriteLine("Server Made");
        }
        private static void CallBack(IAsyncResult e)
        {
            try
            {
                Socket socket = serverSocket.EndAccept(e);
                clientSockets.Add(socket);
                Console.WriteLine("Client Connected");
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
                serverSocket.BeginAccept(new AsyncCallback(CallBack), null);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private static void ReceiveCallBack(IAsyncResult e)
        {
            try
            {
                Socket socket = (Socket)e.AsyncState;
                int received;
                try
                {
                    received = socket.EndReceive(e);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Client forcefully disconnected");
                    socket.Close();
                    clientSockets.Remove(socket);
                    return;
                }
                byte[] dataBuf = new byte[received];
                Array.Copy(buffer, dataBuf, received);
                string text = Encoding.ASCII.GetString(dataBuf);
                Console.WriteLine("Client request: " + text);
                string response = string.Empty;
                
                try
                {
                    if (command.ToLower() == "What Time is it")
                    {
                        response = DateTime.Now.ToString();
                    }
                    else if (command.ToLower() == "Whats your name")
                    {
                        response = "Tyler Gregorcyk";
                    }
                    else
                    {
                        response = "Invaled";
                    }
                }
                catch (Exception et) { Console.WriteLine(et.Message); socket.Close(); clientSockets.Remove(socket); }
                
                if(response == string.Empty)
                {
                    response = "Invaled";
                }
                if (response != string.Empty)
                {
                    Console.WriteLine("Sent To Client: " + response);
                    byte[] data = Encoding.ASCII.GetBytes(response);
                    socket.Send(data);
                    serverSocket.BeginAccept(new AsyncCallback(CallBack), null);
                }
                conn.Close();
                socket.BeginReceive(buffer, 0, bufferSize, SocketFlags.None, ReceiveCallBack, socket);
            }
            catch (Exception) { }
        }
        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            serverSocket.Close();
        }
    }
