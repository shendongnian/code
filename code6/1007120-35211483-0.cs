      var wDependenctResolver = new SignalRUnityResolver(wUnityContainer);
      GlobalHost.DependencyResolver = wDependenctResolver;
      GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(30);
      GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);
      GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(2);
      try
      {
        var hubConfiguration = new HubConfiguration
        {
         
          EnableDetailedErrors = true,
          EnableJavaScriptProxies = true
        };
        appBuilder.MapSignalR("/signalr", hubConfiguration);
        
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to initialize or map SignalR", ex);
      }
      
