    var container = new WindsorContainer();
    
    container.Register(
            Types.FromAssemblyContaining(typeof(ReadCommandHandler<,>)).BasedOn(typeof(ICommandHandler<,>))
            .If(p => !p.IsInterface)
            .WithServiceBase()
    .Configure(
                c => c.ExtendedProperties(
                    Property.ForKey(Castle.Core.Internal.Constants.GenericImplementationMatchingStrategy)
                        .Eq(new GenericImplementationMatchingStrategy()))));
    
    
    
    
    var biz = container.Resolve(typeof(ICommandHandler<IReadCommand<MyFilter>, IEnumerable<MyEntity>>));
