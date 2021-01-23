    StartListening()
    {
        BeginAcceptTcpClient(... EndListening);
    }
    EndListening()
    {
        TcpClient client = EndAcceptTcpClient(..)
        StartClientReceiving(client );
        StartListening();
    }
    StartClientReceiving(TcpClient client)
    {
        client.BeginReceiving(....EndClientReceiving)
    }
 
    EndClientReceiving()
    {
        // if no datareceived, disconnect.
        // HandleData
        StartClientReceiving();
    }
    
