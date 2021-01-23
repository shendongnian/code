    var builder = new ContainerBuilder();
    builder.Register(ctx => LoadSettings()).As<ISettings>().SingleInstance();
    builder.RegisterType<DefaultFoo>().As<IFoo>();
    var container = builder.Build();
    var settings = container.Resolve<ISettings>();
    using(var scope =
      container.BeginLifetimeScope(b => {
        if(settings.ReallyUseSpecificFoo)
        {
          b.RegisterType<SpecificFoo>().As<IFoo>();
        }
      })
    {
      // Resolve things from the nested lifetime scope - it will
      // use the overrides. This will get the SpecificFoo if the
      // configuration setting is true.
      var foo = scope.Resolve<IFoo>();
    }
