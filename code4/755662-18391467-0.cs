    private CachedWebServiceChannelFactory<ICmsDataServiceWcf> factory;
    public ICmsDataServiceWcf GetDataService()
    {
        if (factory == null) // or factory needs rebuilding
        {
            string url = ConfigurationManager.AppSettings["service_url"];
            EndpointAddress endPoint = new EndpointAddress(url);
            var binding = new WSHttpBinding(SecurityMode.None);
            factory = new CachedWebServiceChannelFactory<ICmsDataServiceWcf>
                (binding, endPoint);
        }
        return factory.CreateChannel();
    }
