    var container = new UnityContainer();
    container.RegisterType<IFoo, Foo>();
    container.RegisterType<IBar, Bar>();
    container.RegisterType<IRepository, Repository>();
    container.RegisterType<IService, Service>();
