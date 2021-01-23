    Console.WriteLine("Start");    
    Container _container = new Container();
    _container.Register<IRedisController2, RedisController2>(); // 1
    _container.InterceptWith<MonitoringInterceptor>(type => 
        type == typeof(IRedisController2));
    _container.RegisterSingle<MonitoringInterceptor>();    
    IRedisController2 redisController =
        _container.GetInstance<IRedisController2>(); // 2, 3
    redisController.PrintSomething();
    redisController.PrintOther();    
    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
