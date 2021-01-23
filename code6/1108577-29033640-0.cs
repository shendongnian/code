    Ping pinger = new Ping();
    try
    {
        PingReply reply = pinger.Send(ip);
        if (reply.Status == IPStatus.Success)
        {
        }
        else
        {
        
        }
    }
