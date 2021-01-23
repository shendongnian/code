    private class StateHolder
    {
        public StateHolder(FtpClient client, SynchronizationContext context)
        {
            Client = client;
            Context = context;
        }
    
        public FtpClient Client {get; private set;}
        public SynchronizationContext Context {get; private set;}
    }
    //...
    ftpClient.BeginOpenRead(someString,BeginOpenReadCallback, new StateHolder(ftpClient, SynchronizationContext.Current));
