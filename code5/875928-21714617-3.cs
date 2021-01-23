    var config = GlobalConfiguration.Configuration;
    var index = config.Formatters.IndexOf(config.Formatters.JsonFormatter);
    config.Formatters[index] = new JsonMediaTypeFormatter
    {
        SerializerSettings = new JsonSerializerSettings
        {
            //ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Local
        }
    };
