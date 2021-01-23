    public static string ReverseLookup(string ip)
    {
        if (String.IsNullOrWhiteSpace(ip))
            return ip;
    
        try
        {
            IPHostEntry host = Dns.GetHostEntry(ip);
    
            return host != null ? host.HostName : ip;
        }
        catch (SocketException)
        {
            return ip;
        }
    }
