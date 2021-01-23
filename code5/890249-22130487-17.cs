    services.AddMvc().Configure<MvcOptions>(options => 
    { 
        var formatter = options.OutputFormatters.First(f => f is JsonOutputFormatter) as JsonOutputFormatter;
        formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        formatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
        formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
    });
