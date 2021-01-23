        public ServiceClient EndpointAddressConfiguration()
        {
            ServiceClient newClient = new ServiceClient("httpBindinConfigName","http://hostname/service.svc");
            return newClient;
        }
