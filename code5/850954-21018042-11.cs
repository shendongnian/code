    private static Task StartListener()
    {
        return Task.Run(async () => 
        {
            var tcpListener = TcpListener.Create(8000);
            tcpListener.Start();
            while (true)
            {
                var tcpClient = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine("[Server] Client has connected");
                await HandleConnectionAsync(tcpClient);
            }
        };
    }
