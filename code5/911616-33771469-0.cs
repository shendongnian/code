    var interceptedBuilders = new List<IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>>();
    ContainerBuilder builder = new ContainerBuilder();
    
    interceptedBuilders.Add(builder.RegisterType<First>().As<IFirst>());
    interceptedBuilders.Add(builder.RegisterType<Second>().As<ISecond>());
    
    foreach (var x in interceptedBuilders)
    {              x.EnableInterfaceInterceptors().InterceptedBy(typeof(AInterceptor));
    }
