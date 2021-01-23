    private class StateHolder
    {
        public StateHolder(FtpClient client, SynchronizationContext context)
        {
            Client = client;
            Context = context;
            //SynchronizationContext.Current can return null, this creates a new context that posts to the Thread Pool if called.
            if(Context == null)
                Context = new SynchronizationContext();
        }
    
        public FtpClient Client {get; private set;}
        public SynchronizationContext Context {get; private set;}
    }
    //...
    ftpClient.BeginOpenRead(someString,BeginOpenReadCallback, new StateHolder(ftpClient, SynchronizationContext.Current));
