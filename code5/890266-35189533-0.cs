    services.AddMvc(options =>
    {
        var formatter = new JsonOutputFormatter
        {
            SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
        };
        options.OutputFormatters.Insert(0, formatter);
    });
