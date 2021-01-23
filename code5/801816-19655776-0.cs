    TcpListener server = new TcpListener(localIP, port);
    server.Start();
    while (!shuttingDown)
    {
        if (server.Pending())
        {
            Socket client = server.AcceptSocket();
            if (client != null)
            {
                // do client stuff
            }
        }
        else
            Thread.Sleep(1000);
    }
