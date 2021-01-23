    public static class WebApiConfig
    {
      public static void Register(HttpConfiguration config)
      {
    
        // do stuff
    
        config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
      }
    }
