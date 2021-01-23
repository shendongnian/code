    var builder = new ContainerBuilder();
    // Register the IFoo types - but NOT "As<IFoo>"
    builder.RegisterType<DefaultFoo>();
    builder.RegisterType<SpecificFoo>();
    // In the lambda use Resolve<T> to get the instances.
    builder.Register(ctx => {
        var settings = ctx.Resolve<ISettings>();
        if(settings.ReallyUseSpecificFoo)
        {
          return ctx.Resolve<SpecificFoo>();
        }
        return ctx.Resolve<DefaultFoo>();
      }).As<IFoo>();
