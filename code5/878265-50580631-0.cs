    new JsonSerializerSettings()
    {
        ContractResolver = new new DefaultContractResolver
        {
           NamingStrategy = new CamelCaseNamingStrategy()
        }
    };
