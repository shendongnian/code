    container.Register(Classes.FromAssemblyNamed("Repositories").Pick().WithServiceAllInterfaces());
    container.Register(Component.For<IAccountService>().ImplementedBy<AccountService>()); 
    container.Register(Component.For<IApplicationDBContext>().ImplementedBy<IApplicationDBContext>()); 
    container.Register(Component.For<IApplicationSettingsService>().ImplementedBy<IApplicationSettingsService>()); 
    var viewModelService = _container.Resolve<ViewModelService>();
