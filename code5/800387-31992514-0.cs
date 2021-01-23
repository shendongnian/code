    var container = new UnityContainer();
    container.RegisterType(
                typeof(ICommandHandler<>).MakeGenericType(typeof(DoSomethingCommand<object>)),
                typeof(DoSomethingCommandHandler<object>));
    var res = container.Resolve<ICommandHandler<DoSomethingCommand<object>>>();
