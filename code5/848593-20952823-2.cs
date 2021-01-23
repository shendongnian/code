    Dictionary<string,TcpClient> clientDict;
    List<TcpClient> clientList;
    ...
    void acceptClients()
    {
    
        TcpListener myList;
    
        myList = new TcpListener(IPAddress.Any, 8001);
    
        while (true)
    
        {
            TcpClient client = myList.AcceptTcpClient();
            clientDict.Add("client nickname, id etc.",client);
            clientList.Add(client);
    
            MessageBox.Show("Connection accepted from " + client.Client.LocalEndPoint.ToString());
            if (clientList.count>=8 || clientDict.count>=8)
            {
                break; // I want to break freeeeee!!!!
            }
        }
    }
    ...
    void sendToClient(string nick)
    {
        if (clientDict.ContainsKey(nick))
        {
            TcpClient client = clientDict[nick];
            //and use selected client.
        }
    }
    void broadcast()
    {
        foreach(TcpClient client in clientList) //clientList can be replaced with clientDict.Values
        {
            //and use selected client.
        }
    }
