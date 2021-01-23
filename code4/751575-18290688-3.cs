    unityContainer.RegisterType<Music>(new InjectionConstructor(new Album("Non-singleton", "Non-singleton")));
    unityContainer.RegisterType<Music>(new ContainerControlledLifetimeManager());
    var music = unityContainer.Resolve<Music>();
    var music2 = unityContainer.Resolve<Music>();
    bool areEqual = ReferenceEquals(music, music2);
