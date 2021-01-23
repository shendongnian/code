    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().Configure<MvcOptions>(options => {
            var jsonFormatter = options.OutputFormatters
                .OfType<JsonOutputFormatter>()
                .First();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling =
                ReferenceLoopHandling.Serialize;
            jsonFormatter.SerializerSettings.PreserveReferencesHandling =
                PreserveReferencesHandling.Objects;
        });
    }
