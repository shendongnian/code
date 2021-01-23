      private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
          {
    
          var config = new ConfigurationOptions();
                config.EndPoints.Add(cachename);
                config.Password = password;
                config.Ssl = true;
                config.SyncTimeout = 150;
    
               return ConnectionMultiplexer.Connect(config);
          });
