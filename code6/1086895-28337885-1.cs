    public static FindResponse Discover(FindCriteria findCriteria, DiscoveryEndpoint discoveryEndpoint = null)
    {
        if (discoveryEndpoint == null) 
          discoveryEndpoint = new UdpDiscoveryEndpoint();
        using (var client = new DiscoveryClient(discoveryEndpoint))
        {
            return client.Find(findCriteria);
        }
    }
