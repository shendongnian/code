    public ServiceEndpoint Endpoint
    {
        get
        {
            TryDisableSharing();
            return GetChannelFactory().Endpoint;
        }
    }
