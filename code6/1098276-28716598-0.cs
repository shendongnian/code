    public static class AppCache
    {
        public static DataCache Cache { get; private set; }
        static AppCache()
        {
            List<DataCacheServerEndpoint> servers = new List<DataCacheServerEndpoint>(1);
            servers.Add(new DataCacheServerEndpoint("ServerName", 22233)); //22233 is the default port
            DataCacheFactoryConfiguration configuration = new DataCacheFactoryConfiguration
            {
                Servers = servers,
                LocalCacheProperties = new DataCacheLocalCacheProperties(),
                SecurityProperties = new DataCacheSecurity(),
                RequestTimeout = new TimeSpan(0, 0, 300),
                MaxConnectionsToServer = 10,
                ChannelOpenTimeout = new TimeSpan(0, 0, 300),
                TransportProperties = new DataCacheTransportProperties() { MaxBufferSize = int.MaxValue, MaxBufferPoolSize = long.MaxValue }
            };
            DataCacheClientLogManager.ChangeLogLevel(System.Diagnostics.TraceLevel.Off);
            var _factory = new DataCacheFactory(configuration);
            Cache = _factory.GetCache("MyCache");
        }
    }
