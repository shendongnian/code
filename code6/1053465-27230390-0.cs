    builder.Register<FirstViewModel>(c => 
        using (var scope = c.BeginLifetimeScope())
            new FirstViewModel(
                scope.Resolve<FirstService>(), 
                scope.Resolve<SecondService>(), 
                scope.Resolve<OtherService>()
        ));
    
    builder.Register<SecondViewModel>(c => 
        using (var scope = c.BeginLifetimeScope())
            new SecondViewModel(
                scope.Resolve<FirstService>(), 
                scope.Resolve<SecondService>(), 
                scope.Resolve<OtherService>()
        ));
