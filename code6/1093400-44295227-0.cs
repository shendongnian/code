    public static HttpConfiguration BreezeControllerCamelCase
            {
                get
                {
                    var config = new HttpConfiguration();
                    var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
                    jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    jsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
    
                    return config;
                }
            }
