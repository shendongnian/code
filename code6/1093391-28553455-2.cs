    protected void Application_Start()
    {
        HttpConfiguration config = GlobalConfiguration.Configuration;
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
    }
