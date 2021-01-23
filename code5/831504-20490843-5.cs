    async void Startup(Boolean succeed) {
      var serviceProvider = new ServiceProvider();
      try {
        var sessionId = await PerformStartup(serviceProvider, succeed);
        Console.WriteLine(sessionId);
      }
      catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }
