    ContainerBuilder builder = new Autofac.ContainerBuilder();
    builder.RegisterModule(new AggregatedEnumerableModule<IServer>());
    builder.RegisterType<MyType>().As<IContainer<IServer>>();
    builder.RegisterType<Server3>().As<IServer>();
    IContainer container = builder.Build();
    IEnumerable<IServer> pouets = container.Resolve<IEnumerable<IServer>>();
 
