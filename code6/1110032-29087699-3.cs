        ContainerBuilder cb = new ContainerBuilder();
        cb.RegisterModule(new CallbackModule());
        cb.RegisterType<Worker1>().As<ICallback>().AsSelf();
        cb.RegisterType<Worker2>().As<ICallback>().AsSelf();
        IContainer container = cb.Build();
