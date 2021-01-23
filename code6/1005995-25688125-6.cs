    var builder = new ContainerBuilder();
    builder.Register(b => {
        
        var factories = new Dictionary<Type, Func<BaseViewModel>> {
            { typeof (FirstViewModel), () => new FirstViewModel() },
            { typeof (SecondViewModel), () => new SecondViewModel(b.Resolve<ISomeDependency>()) },
        };
        return new ViewModelFactory(factories);
    }).As<IViewModelFactory>();
