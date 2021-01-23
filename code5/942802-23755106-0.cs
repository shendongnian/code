            DataCacheServerEndpoint[] servers = new DataCacheServerEndpoint[1];
            servers[0] = new DataCacheServerEndpoint("localhost", 22233);
            DataCacheFactoryConfiguration conf = new DataCacheFactoryConfiguration();
            conf.Servers = servers;
            DataCacheFactory factory = new DataCacheFactory(conf);
