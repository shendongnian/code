    ...
    public void ServiceCall(Action<IFileService> action)
    {
        IFileService proxy = null;
        ChannelFactory<IFileService> factory = null;
        try
        {
            factory = new ChannelFactory<IFileService>("*");
            proxy = factory.CreateChannel();
            return action(proxy);
        }
        finally
        {
            CloseConnection(proxy, factory);
        }
    }
