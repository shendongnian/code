    var kernel = new StandardKernel();
    kernel.Bind(x => x.FromThisAssembly()
        .SelectAllClasses()
        .InheritedFromAny(
            new[]
            {
                typeof(ICommandHandler<>), 
                typeof(IQueryHandler<,>)
            })
        .BindDefaultInterfaces());
    kernel.Bind<IDependencyResolver>().ToMethod(x => DependencyResolver.Current);
    ShortBus.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
