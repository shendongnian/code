    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ...
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jsonSettings;
        }
    }
