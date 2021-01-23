    var container = new UnityContainer();
    container
         .ConfigureAutoRegistration()
         .ExcludeAssemblies(a => a.GetName().FullName.Contains("Test"))
         .Include(If.Implements<ILogger>, Then.Register().UsingPerCallMode())
             .Include(If.ImplementsITypeName, Then.Register().WithTypeName())
             .Include(If.Implements<ICustomerRepository>, Then.Register().WithName("Sample"))
             .Include(If.Implements<IOrderRepository>,
                   Then.Register().AsSingleInterfaceOfType().UsingPerCallMode())
             .Include(If.DecoratedWith<LoggerAttribute>,
                   Then.Register()
                          .As<IDisposable>()
                          .WithTypeName()
                          .UsingLifetime<MyLifetimeManager>())
             .Exclude(t => t.Name.Contains("Trace"))
             .ApplyAutoRegistration();
