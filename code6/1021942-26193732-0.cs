    BinaryReader reader = new BinaryReader(clientSocket.GetStream());
    while(true)
    {
        string message = reader.ReadString();
        foreach(var client in clients)
        {
            //send message to client
        }
    }
