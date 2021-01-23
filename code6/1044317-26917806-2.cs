    class SocketServer
    {
        private readonly Socket _listen;
        public SocketServer(int port)
        {
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Loopback, port);
            _listen = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _listen.Bind(listenEndPoint);
            _listen.Listen(1);
            _listen.BeginAccept(_Accept, null);
        }
        public void Stop()
        {
            _listen.Close();
        }
        private async void _Accept(IAsyncResult result)
        {
            try
            {
                using (Socket client = _listen.EndAccept(result))
                using (NetworkStream stream = new NetworkStream(client))
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    Console.WriteLine("SERVER: accepted new client");
                    string text;
                    while ((text = await reader.ReadLineAsync()) != null)
                    {
                        Console.WriteLine("SERVER: received \"" + text + "\"");
                        writer.WriteLine(text);
                        writer.Flush();
                    }
                }
                Console.WriteLine("SERVER: end-of-stream");
                // Don't accept a new client until the previous one is done
                _listen.BeginAccept(_Accept, null);
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("SERVER: server was closed");
            }
            catch (SocketException e)
            {
                Console.WriteLine("SERVER: Exception: " + e);
            }
        }
    }
