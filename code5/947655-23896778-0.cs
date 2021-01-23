    public string GetStatus(string serverID, List<Server> collection)
    {
        string result = string.Empty;
    
        foreach(Server server in collection)
        {
             if (server.ServerID == serverID)
             {
                 result = server.Status;
                 break;
             }
        }
    
        return result;
    }
