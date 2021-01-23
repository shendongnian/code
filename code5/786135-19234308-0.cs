        private static ManualResetEvent allDone = new ManualResetEvent(false);
        private Socket ear;
        public void Start()
        {
            new Thread(() => StartListening()).Start();
        }
        private void StartListening()
        {
            IP = Dns.GetHostAddresses(Dns.GetHostName()).Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
            port = 11221;
            IPEndPoint localEndPoint = new IPEndPoint(IP, Port);
            ear = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ear.Bind(localEndPoint);
            ear.Listen(100);
            IsListening = true;
            while (IsListening)
            {
                allDone.Reset();
                ear.BeginAccept(new AsyncCallback(AcceptCallback), ear);
                allDone.WaitOne();
            }
            Console.WriteLine("Socket Closed");
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            if (IsListening == false) return;
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        public static void ReadCallback(IAsyncResult ar) 
        {
            String content = String.Empty;
        
            StateObject state = (StateObject) ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0) {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1) {
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content );
                } 
                else 
                {
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }
        public void Stop()
        {
            IsListening = false;
            ear.Close();
        }
