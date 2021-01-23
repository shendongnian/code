    var kernel = new StandardKernel();
    // 2nd Step left out: load all IModule`s ..
    
    var bus = ServiceBusFactory.New(sbc =>
    {
        //other configuration options
 
        foreach(var metadata in kernel.GetAll<SubscriptionMetadata>())
        {
            sbc.Subscribe(subs =>
            {
                subs.Consumer(metadata.ConsumerType, kernel)
            });
        }
    });
