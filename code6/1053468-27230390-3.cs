    //First builder
    ContainerBuilder builder = new ContainerBuilder();
    //Register context as Lifetime dependent.
    builder.Register(ctx => new EFContext())
                .InstancePerLifetimeScope();
    //Register services.
    builder.Register<FirstService>(c => new FirstService(c.Resolve<EFContext>()));
    builder.Register<SecondService>(c => new SecondService(c.Resolve<EFContext>()));
    builder.Register<OtherService>(c => new OtherService(c.Resolve<EFContext>()));
    //Build first builder to work with scopes.
    var container = builder.Build();
    //Create a second builder.
    ContainerBuilder builder2 = new ContainerBuilder();
    using (var scope = container.BeginLifetimeScope())
    {
        //Create services, since lambda is executed after scope is disposed.
        var firstService = scope.Resolve<FirstService>();
        var secondService = scope.Resolve<SecondService>();
        var otherService = scope.Resolve<OtherService>();
        //Register viewmodel with second builder.
        builder2.Register<FirstViewModel>(c => new FirstViewModel(
            firstService,
            secondService,
            otherService
        ));
    }
    using (var scope = container.BeginLifetimeScope())
    {
        //Create services, since lambda is executed after scope is disposed.
        var firstService = scope.Resolve<FirstService>();
        var secondService = scope.Resolve<SecondService>();
        var otherService = scope.Resolve<OtherService>();
        //Register viewmodel with second builder.
        builder2.Register<SecondViewModel>(c => new SecondViewModel(
            firstService,
            secondService,
            otherService
        ));
    }
    //Build second builder.
    var container2 = builder2.Build();
    //Merge registration of second builder with the first.
    foreach (var registration in container2.ComponentRegistry.Registrations)
        container.ComponentRegistry.Register(registration);
    //Resolve the viewmodels from the container.
    var firstViewModel = container.Resolve<FirstViewModel>();
    var secondViewModel = container.Resolve<SecondViewModel>();
