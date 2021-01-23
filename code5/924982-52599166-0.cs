    using (ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost"))
    {
        IDatabase db = connection.GetDatabase();
        ISubscriber subscriber = connection.GetSubscriber();
    
        subscriber.Subscribe($"__keyspace@0__:{channel}", (channel, value) =>
            {
              // Do whatever channel specific handling you need to do here, in my case I used exact Key name that I wanted expiration event for.  
            }
        );
    }
