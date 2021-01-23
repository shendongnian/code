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
                var task = StartHandleConnectionAsync(tcpClient);
                // if already faulted, re-throw any error on the calling context
                if (task.IsFaulted)
                    task.Wait();
            }
        });
    }
