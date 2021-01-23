    var container = new WindsorContainer();
    container.Register(Component.For<CachingInterceptor>()
	.Instance(new CachingInterceptor(new Cache(TimeoutStyle.RenewTimoutOnQuery, TimeSpan.FromSeconds(3)))));
    container.Register(Component.For<IRepo>().ImplementedBy<Repo>().Named("Without"));
    container.Register(Component.For<IRepo>().ImplementedBy<Repo>().Interceptors<CachingInterceptor>().Named("With"));
    container.Register(Component.For<Service>());
    container.Register(Component.For<Game>().DependsOn(Property.ForKey<IRepo>().Is("With")));
    var service = container.Resolve<Service>();
    var game = container.Resolve<Game>();
    Console.WriteLine("Cache is not used");
    service.Invoke();
    service.Invoke();
    Console.WriteLine();
    Console.WriteLine("Cache is used");
    game.Invoke();
    game.Invoke();
