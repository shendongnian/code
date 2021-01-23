    public static void Register(HttpConfiguration config)
    {
        // ...
        
        // remove this line:
        config.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects;
    }
