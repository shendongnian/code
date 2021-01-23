    Ping ping = new Ping();
    PingReply pingReply = ping.Send("IP Address");
    
    if(pingReply.Status == IPStatus.Success)
    {
       //Machine is online
    }
