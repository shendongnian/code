    var builder = new ContainerBuilder();
    builder.Register(ctx => LoadSettings()).As<ISettings>().SingleInstance();
    builder.RegisterType<DefaultFoo>().As<IFoo>();
    var container = builder.Build();
    var settings = container.Resolve<ISettings>();
    if(settings.ReallyUseSpecificFoo)
    {
      var updater = new ContainerBuilder();
      updater.RegisterType<SpecificFoo>().As<IFoo>();
      updater.Update(container);
    }
