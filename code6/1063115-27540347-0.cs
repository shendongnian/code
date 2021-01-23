    while (running)
    {
        TcpClient tcpclient = await listener.AcceptTcpClientAsync(); // NOTE 1 Below
        Client client = new Client(tcpclient, 
            ((IPEndPoint)tcpclient.Client.RemoteEndPoint).Address.ToString());
        Task handshakeTask = Task.Factory.StartNew(() => // NOTE 2 Below
        {
            ClientHandle.AddToClientPool(client);
            SendRequestInformation(client, 1);
        });
    }
