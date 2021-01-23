    ContainerBuilder builder = new ContainerBuilder();
     
    // critical line
    builder.Register(c => new EFRepository()).As<IRepository>();
    
    IContainer container = builder.Build();
    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
