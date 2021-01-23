    services.AddMvc().Configure<MvcOptions>(options =>
    {
        var jsonOutputFormatter = new JsonOutputFormatter();
        jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        jsonOutputFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
        options.OutputFormatters.Insert(0, jsonOutputFormatter);
    });
