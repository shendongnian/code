    using (var subscription = redisClient.CreateSubscription())
    {
        subscription.OnUnSubscribe = channel => 
            Log.Debug("OnUnSubscribe: " + channel);
        subscription.OnMessage = (channel, msg) =>
        {
            if (msg == "STOP")
            {
                Log.Debug("Stop Command Issued");
                Log.Debug("Unsubscribing from all Channels...");
                subscription.UnSubscribeFromAllChannels(); //Unblocks thread.
            }
        };
        subscription.SubscribeToChannels(QueueNames.TopicIn); //blocks thread
    }
