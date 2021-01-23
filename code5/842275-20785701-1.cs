    builder.RegisterAssemblyTypes(typeof(AutofacRegistrationOrderTest).Assembly)
        .Where(t => t != typeof(BackgroundTaskScheduler))
        .AsImplementedInterfaces()
        .AsSelf();
                
    builder.Register(
        c => new BackgroundTaskScheduler(c.Resolve<IJobRunner>(), triggerInterval))
        .AsImplementedInterfaces()
        .SingleInstance();
