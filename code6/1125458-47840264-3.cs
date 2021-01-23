    public static int POOL_SIZE = 100;
    private static readonly Object lockPookRoundRobin = new Object();
    private static Lazy<Context>[] lazyConnection = null;
    //Static initializer to be executed once on the first call
    private static void InitConnectionPool()
    {
        lock (lockPookRoundRobin)
        {
            if (lazyConnection == null) {
                 lazyConnection = new Lazy<Context>[POOL_SIZE];
            }
            for (int i = 0; i < POOL_SIZE; i++){
                if (lazyConnection[i] == null)
                    lazyConnection[i] = new Lazy<Context>(() => new Context("YOUR_CONNECTION_STRING", new CachingFramework.Redis.Serializers.JsonSerializer()));
            }
        }
    }
    private static Context GetLeastLoadedConnection()
    {
        //choose the least loaded connection from the pool
        /*
        var minValue = lazyConnection.Min((lazyCtx) => lazyCtx.Value.GetConnectionMultiplexer().GetCounters().TotalOutstanding);
        var lazyContext = lazyConnection.Where((lazyCtx) => lazyCtx.Value.GetConnectionMultiplexer().GetCounters().TotalOutstanding == minValue).First();
        */
        
        // UPDATE following @Luke Foust comment below
        Lazy<Connection> lazyContext;
		
		var loadedLazys = lazyConnection.Where((lazy) => lazy.IsValueCreated);
		if(loadedLazys.Count()==lazyConnection.Count()){
			var minValue = loadedLazys.Min((lazy) => lazy.Value.TotalOutstanding);
			lazyContext = loadedLazys.Where((lazy) => lazy.Value.TotalOutstanding == minValue).First();
		}else{
			lazyContext = lazyConnection[loadedLazys.Count()];
		}
        return lazyContext.Value;
    }
    private static Context Connection
    {
        get
        {
            lock (lockPookRoundRobin)
            {
                return GetLeastLoadedConnection();
            }
        }
    }
    public RedisCacheService()
    {
        InitConnectionPool();
    }
