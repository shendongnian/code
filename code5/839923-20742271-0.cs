    var kernel = new StandardKernel();
    kernel.Bind<IConnector>().To<CoreConnector>().WhenInjectedInto<AuditingConnector>().InSingletonScope();
    kernel.Bind<IConnector>()
        .To<AuditingConnector>()
        .WhenInjectedInto<LoggingConnector>()
        .WithConstructorArgument("id", 
           ctx => ctx.Request.ParentContext.Parameters
             .Single(x => x.Name == "id")
             .GetValue(ctx, null));
    kernel.Bind<IConnector>().To<LoggingConnector>();
    kernel.Bind<IConnectorFactory>().ToFactory();
