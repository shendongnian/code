    GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
    var jSettings = new JsonSerializerSettings();
    
    GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;
    GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("xml", "true", new MediaTypeHeaderValue("application/xml")));
