    Type[] typesToRegisterManually = new[]
    {
        typeof(CachedTeamService)
    };
    container.RegisterManyForOpenGeneric(typeof(IEventHandler<>),
        (service, impls) =>
        {
            container.RegisterAll(service, impls.Except(typesToRegisterManually));
        },
        assemblies);
    var registration = 
        Lifestyle.Singleton.CreateRegistration<CachedTeamService>(container);
    container.AddRegistration(typeof(ITeamService), registration);
    container.AddRegistration(typeof(ICanRefreshCache), registration);
    // Using SimpleInjector.Advanced
    container.AppendToCollection(typeof(IEventHandler<TeamCreated>), registration);
