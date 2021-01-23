    var registration = Lifestyle.Singleton.CreateRegistration<UserService>(container);
    container.AddRegistration(typeof(IUserService), registration);
    container.AddRegistration(typeof(UserService), registration);
    container.RegisterCollection(typeof(IObserver<>),
        new[] { typeof(IObserver<>).Assembly });
    // Simple Injector v2.x syntax
    container.RegisterManyForOpenGeneric(typeof(IObserver<>),
        container.RegisterAll,
        typeof(IObserver<>).Assembly);
