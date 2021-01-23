    while (true)
    {
        Console.WriteLine("Waiting for client to connect...");
        Socket client = server.AcceptSocket(); // This is a blocking call...
        Console.WriteLine("Client connected...");
        IPEndPoint clientAddress = (IPEndPoint) client.RemoteEndPoint;
        Console.WriteLine("Accepted client: {0}:{1}", clientAddress.Address, clientAddress.Port);
        client.Close();
        Console.WriteLine("Closed connection to: {0}:{1}", clientAddress.Address, clientAddress.Port);
    }
