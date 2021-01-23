    var container = builder.Build();
    using (var scope = container.BeginLifetimeScope())
        var viewModel = new FirstViewModel(
            scope.Resolve<FirstService>(), 
            scope.Resolve<SecondService>(), 
            scope.Resolve<OtherService>()
        );
    using (var scope = container.BeginLifetimeScope())
        var viewModel = new SecondViewModel(
            scope.Resolve<FirstService>(), 
            scope.Resolve<SecondService>(), 
            scope.Resolve<OtherService>()
        );
