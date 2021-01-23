        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<Pouet>().AsSelf();
        builder.RegisterType<Foo>().AsSelf();
        builder.RegisterType<Bar1>().As<IBar>();
        builder.RegisterType<Bar2>().As<IBar>();
        IContainer container = builder.Build();
        IEnumerable<Pouet> pouets = container.Resolve<IEnumerable<Pouet>>();
        Console.WriteLine(pouets.Count()); // => must return 2 here !
