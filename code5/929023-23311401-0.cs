    //using Autofac
    var builder = new ContainerBuilder();
    containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();
    
    var container = builder.Build();
    var myItems = Container.Resolve<ISomeInterface>();
    
    foreach(var item in myItems){
        item.DoSomething()
    }
