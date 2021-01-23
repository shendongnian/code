    var client = new MongoClient(connString);
    var server = client.GetServer();
    while (server.State == MongoServerState.Disconnected)
    {
       Thread.Sleep(1000);
       try
       { 
          server.Reconnect(); 
       }
       catch (Exception ex)
       { 
          Debug.WriteLine("Failed to connect mongodb {0} Attempt Count: {1}",
                           ex, server.ConnectionAttempt); 
       }
    }
    
 
