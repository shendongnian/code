    FluentContractResolver.SearchAssemblies(typeof(MyModel).Assembly);
    Newtonsoft.Json.JsonConvert.DefaultSettings = () => 
    {
        return new Newtonsoft.Json.JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ContractResolver = new FluentContractResolver()
        };
    };
