    protected void Application_Start()
    {
     
    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
    serializerSettings.Converters.Add(new IsoDateTimeConverter());
    var jsonFormatter = new JsonNetFormatter(serializerSettings);
    jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    GlobalConfiguration.Configuration.Formatters.Insert(0, jsonFormatter);
    }
