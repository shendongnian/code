    public static string ReverseLookup(string ip)
    {
        if (String.IsNullOrEmpty(ip)) 
            return ip;
    
         try 
         {
           return Dns.GetHostEntry(ip)
              .Select(entry => entry.HostName)
              .FirstOrDefault() ?? ip;
         } 
         catch(SocketException) 
         { return ip; }
    }
