    var containerBuilder = new ContainerBuilder();
    containerBuilder.RegisterType<PersonWithJacket>();
    var childContainer1 = new MultitenantContainer(new NullTenantIdStrategy(), containerBuilder.Build());
    childContainer1.ConfigureTenant(null, builder => builder.Register(context => new Jacket("Hugo Boss")));
    var childContainer2 = new MultitenantContainer(new NullTenantIdStrategy(), containerBuilder.Build());
    childContainer2.ConfigureTenant(null, builder => builder.Register(context => new Jacket("H&M")));
    var personWithHugoBossJacket = childContainer1.Resolve<PersonWithJacket>();
    var personWithHandMJacket = childContainer2.Resolve<PersonWithJacket>();
