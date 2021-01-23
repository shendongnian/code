    public static class WebApiConfig
        {
    //....
            public static void Register(HttpConfiguration config)
            {  config.Formatters.XmlFormatter.UseXmlSerializer = true;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
            Newtonsoft.Json.PreserveReferencesHandling.Objects;
    }
