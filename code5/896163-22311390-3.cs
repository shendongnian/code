    PingReply pingReply;
    do
    {
        pingReply = ping.Send(pcName, 100, buffer, pingOpt);                    
    }
    while(pingReply.Status != IPStatus.Success);
    return pingReply.Address.ToString();    
