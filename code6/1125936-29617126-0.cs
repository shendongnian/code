    public void Send(string name, string message)
    {
         var user = name;
         if(string.IsNullOrEmpty(user))
              user = "Anonymous";
    
         Clients.All.broadcastMessage(user, message);
    }
