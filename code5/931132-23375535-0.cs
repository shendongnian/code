    private object clientListLock = new object();
    public void ListnerFunc()
    {
        while (true)
        {
            client = listner.AcceptTcpClient();
            
            lock(clientListLock)
            {
               clientStream.Add(client.GetStream());
               if (client.Connected)
               {
                   clientsList.Add(client);
               }
            }
        }
    }
    public void WaiterFunc()
    {
        while (true)
        {
            lock (clientListLock)
            {
               foreach (NetworkStream stream in clientStream)
               {
                   clientMsg = formatter.Deserialize(stream).ToString();
               }
            }
        }
    }
