    ContainerBuilder builder = new ContainerBuilder();
    
    builder.Register(ctx => new EFContext())
                .InstancePerLifetimeScope();
    
    builder.Register<FirstService>(c => new FirstService(c.Resolve<EFContext>()));
    builder.Register<SecondService>(c => new SecondService(c.Resolve<EFContext>()));
    builder.Register<OtherService>(c => new OtherService(c.Resolve<EFContext>()));
    
    builder.Register<FirstViewModel>(c => 
                new FirstViewModel(
                    c.Resolve<FirstService>(), 
                    c.Resolve<SecondService>(), 
                    c.Resolve<OtherService>()
                ));
    builder.Register<SecondViewModel>(c => 
                new SecondViewModel(
                    c.Resolve<FirstService>(), 
                    c.Resolve<SecondService>(), 
                    c.Resolve<OtherService>()
                ));
