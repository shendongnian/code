    // Handle new connection
    private static Task HandleConnectionAsync(TcpClient tcpClient)
    {
        return Task.Run(async () =>
        {
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
        });
    }
