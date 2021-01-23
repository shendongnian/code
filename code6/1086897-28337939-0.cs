    public static FindResponse Discover(FindCriteria findCriteria, DiscoveryEndpoint discoveryEndpoint = null)
        {
            FindResponse response = null;
            try
            {
                if (discoveryEndpoint == null) { discoveryEndpoint = new UdpDiscoveryEndpoint(); }
                using (DiscoveryClient discoveryClient = new DiscoveryClient(discoveryEndpoint))
                {
                    response = discoveryClient.Find(findCriteria);
                    discoveryClient.Close();
                }
            }
            finally
            {   
            }
            return response;
        }
