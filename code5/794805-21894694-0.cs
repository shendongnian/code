    myConnection = new HubConnection(endpoint);
    
    proxy = _conn.CreateHubProxy("DataHub");
    proxy.On<string>("ServerEvent", ClientHandler);
    
    myConnection.Start();
    
    proxy.Invoke("hubMethod", ...);
