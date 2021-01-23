        PushBroker broker = new PushBroker();
        broker.OnChannelCreated += broker_OnChannelCreated;
        broker.OnChannelDestroyed += broker_OnChannelDestroyed;
        broker.OnChannelException += broker_OnChannelException;
        broker.OnNotificationRequeue += broker_OnNotificationRequeue;
        broker.OnServiceException += broker_OnServiceException;
        broker.OnNotificationSent += broker_OnNotificationSent;
        broker.OnNotificationFailed += broker_OnNotificationFailed;
        // Now you can register the service.
        broker.RegisterAppleService(new PushSharp.Apple.ApplePushChannelSettings(false, appleCert, "XXXXX"));
        
