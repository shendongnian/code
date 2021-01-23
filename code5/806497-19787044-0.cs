    builder
        .RegisterAssemblyTypes(typeof (IResourceFinder).Assembly)
        .AsImplementedInterfaces();
    /* process LogInjectionModule */
    IContainer container = builder.Build();
    var updateBuilder = new ContainerBuilder();
    updateBuilder
        .Register(x => new ClassThatNeedsILog(x.Resolve<ILog>()))
        .AsImplementedInterfaces();
    updateBuilder.Update(container);
