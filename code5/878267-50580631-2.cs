    new JsonSerializerSettings()
    {
        ContractResolver = new DefaultContractResolver
        {
           NamingStrategy = new CamelCaseNamingStrategy()
        }
    };
