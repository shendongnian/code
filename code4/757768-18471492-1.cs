    IUnityContainer container = new UnityContainer();
    container.RegisterType<IQueue, MessageQueue>("ReceiveQueue",
        new InjectionConstructor("receivePath"));
    container.RegisterType<IQueue, MessageQueue>("SendQueue",
        new InjectionConstructor("sendPath"));
    container.RegisterType<Example>(new InjectionFactory(c =>
        new Example(c.Resolve<IQueue>("ReceiveQueue"),
                    c.Resolve<IQueue>("SendQueue"))));
    Example example = container.Resolve<Example>();
