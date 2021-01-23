    public static JsonSerializerSettings JsonSerializerSettings
    {
        get
        {
            return GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
        }
    }
