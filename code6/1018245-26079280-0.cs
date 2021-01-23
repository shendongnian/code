    static void Main(string[] args)
    {
      MainAsync().Wait();
    }
    static async Task MainAsync()
    {
      var url = System.Configuration.ConfigurationManager.AppSettings["CentrisURL"];
      ...
    }
