    try
    {
         ClientInfo ifno = GetClient(username);
    }
    catch (Exception ex)
    {
          // ex.Message : contain client not found  
    }
    public ClientInfo GetClient(string username)
    {        
       SmsHandler ci = new SmsHandler();
       ClientInfo clientInfo = new ClientInfo();
       //the below code gives the client
       var client = dbContext.Clients.FirstOrDefault(m => m.Username == username);
       if (client != null)
       {
          clientInfo = ci.GetClientInfo(client.Id);
          return clientInfo;
       }
       else
       {
           throw new Exception("Client not found !");
       }
    }
