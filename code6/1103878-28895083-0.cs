    ...
    public void ServiceCall(Action<IServiceContract> action)
    {
        IFileService proxy = null;
        ChannelFactory<IFileService> factory = null;
        try
        {
            factory = new ChannelFactory<IFileService>("*");
            // This has to be casted to your service contract
            proxy = factory.CreateChannel();
            return action(proxy);
        }
        finally
        {
            CloseConnection(proxy, factory);
        }
    }
