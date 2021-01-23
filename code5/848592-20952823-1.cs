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
