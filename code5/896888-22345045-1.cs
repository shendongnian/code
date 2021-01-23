     var builder = new ContainerBuilder();
     // Custom registration might happen before and/or after the call to Chain
     builder.RegisterType<MyCustomService>().As<IMyCustomService>();
     builder.RegisterType<MyExternalServiceReplacement>().As<IExternalService>();
     //Chain(builder, someExternalProvider);
     builder.RegisterSource(new MyRegistrationSoruce(new ServiceProvider()));
     
     IContainer container = builder.Build();
