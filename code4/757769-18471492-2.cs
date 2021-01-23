    IUnityContainer container = new UnityContainer();
    container.RegisterType<IQueue, MessageQueue>("ReceiveQueue", 
        new InjectionConstructor("receivePath"));
    container.RegisterType<IQueue, MessageQueue>("SendQueue",
        new InjectionConstructor("sendPath"));
    container.RegisterType<Example>(
        new InjectionConstructor(
            new ResolvedParameter<IQueue>("ReceiveQueue"),
            new ResolvedParameter<IQueue>("SendQueue")));
    Example example = container.Resolve<Example>();
