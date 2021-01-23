    builder.RegisterAssemblyTypes(typeof (RegistrationController).Assembly)
        .AsImplementedInterfaces()
        .AsSelf();
    builder.Register(
        c => new BackgroundTaskScheduler(c.Resolve<IJobRunner>(), triggerInterval))
        .AsImplementedInterfaces().SingleInstance();
