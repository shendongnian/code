    public static class WebApiConfig
    {
      public static void Register(HttpConfiguration config)
      {
    
        // do stuff
    
        var cors = new EnableCorsAttribute("*", "*", "*") {SupportsCredentials = true};
        config.EnableCors(cors);
      }
    }
