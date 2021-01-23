    private static string GetSubDomain(Uri url)
    {
        if (url.HostNameType == UriHostNameType.Dns)
        {
            string host = url.Host;
            var nodes = host.split('.');
            int startNode = 0;
            if(nodes[0] == 'www') startNode = 1;
               
            return string.format("{0}.{1}", nodes[startNode], nodes[startNode + 1];
        }
        return null; 
    }
