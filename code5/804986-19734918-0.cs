    private static string GetSubDomain(Uri url)
    {
        if (url.HostNameType == UriHostNameType.Dns)
        {
    
            string host = url.Host;   
            String[] subDomains = host.Split('.');
            return subDomains[0] + "." + subDomains[1];
         }
        return null; 
    }
