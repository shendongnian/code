    using (ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost"))
    {
        IDatabase db = connection.GetDatabase();
        ISubscriber subscriber = connection.GetSubscriber();
    
        subscriber.Subscribe("__keyspace@0__:*", (channel, value) =>
            {
                if ((string)channel == "__keyspace@0__:users" && (string)value == "sadd")
                {
                    // Do stuff if some item is added to a hypothethical "users" set in Redis
                }
            }
        );
    }
