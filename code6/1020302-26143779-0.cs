    [HubMethodName("sendNotifications")]
    public void SendNotifications()
    {
        //using...
        
        //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<notificationHub>();
        //return context.Clients.All.RecieveNotification(role, descrip);
        Clients.All.RecieveNotification(role, descrip);
    }
    
