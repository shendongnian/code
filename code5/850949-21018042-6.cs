    class Program
    {
        // The core server task
        private static async Task StartListener()
        {
            var tcpListener = TcpListener.Create(8000);
            tcpListener.Start();
            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine("[Server] Client has connected");
                await HandleConnectionAsync(tcpClient);
            }
        }
        // Handle new connection
        private static async Task HandleConnectionAsync(TcpClient tcpClient)
        {
            await Task.Yield(); 
            // continue asynchronously on another threads
            using (var networkStream = tcpClient.GetStream())
            {
                var buffer = new byte[4096];
                Console.WriteLine("[Server] Reading from client");
                var byteCount = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                var request = Encoding.UTF8.GetString(buffer, 0, byteCount);
                Console.WriteLine("[Server] Client wrote {0}", request);
                var serverResponseBytes = Encoding.UTF8.GetBytes("Hello from server");
                await networkStream.WriteAsync(serverResponseBytes, 0, serverResponseBytes.Length);
                Console.WriteLine("[Server] Response has been written");
            }
        }
        // The entry point of the console app
        static void Main(string[] args)
        {
            Console.WriteLine("Hit Ctrl-C to exit.");
            StartListener().Wait();
        }  
    }
