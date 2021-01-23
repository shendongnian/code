    // add a reference to System.Configuration
    var entityCnxStringBuilder = new EntityConnectionStringBuilder
    {
        ProviderConnectionString = new  SqlConnectionStringBuilder(System.Configuration.ConfigurationManager
                   .ConnectionStrings[configNameEf].ConnectionString).ConnectionString
    };
