    var resolver = new DefaultContractResolver
    {
        NamingStrategy = new CamelCaseNamingStrategy
        {
            ProcessDictionaryKeys = false,
            OverrideSpecifiedNames = true
        }
    };
    config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = resolver;
