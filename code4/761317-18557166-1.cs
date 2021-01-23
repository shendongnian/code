    {
        TcpListener listener = new TcpListener(IPAddress.Any, 8082);
        listener.Start();
        AcceptClient();
    }
    void AcceptClient()
    { 
        listener.BeginAccept(ClientConnected, null);
    }
    void ClientConnected(IAsyncResult ar)
    {
        TcpClient client = listener.EndAccept();
        AcceptClient();
        // Now you can send or receive data using the client variable.
    }
