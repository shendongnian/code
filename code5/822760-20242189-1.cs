    using Newtonsoft.Json;
    
    protected void Application_Start()
    {
       SerializeSettings(GlobalConfiguration.Configuration);
                    
    }
    void SerializeSettings(HttpConfiguration config)
    {
       JsonSerializerSettings jsonSetting = new JsonSerializerSettings();
       jsonSetting.Converters.Add(new Converters.StringEnumConverter());
       config.Formatters.JsonFormatter.SerializerSettings = jsonSetting;
    }
