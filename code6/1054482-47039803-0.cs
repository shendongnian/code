    IWebHostBuilder builder = new WebHostBuilder()
        .UseStartup<Startup>()
        .ConfigureServices(services =>
        {
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("doc-name", new Info { Title = "Title", Version = "v1" });
            });
        });
    
    JsonSerializerSettings mvcSerializerSettings;
    SwaggerDocument document;
    using (var testServer = new TestServer(builder))
    {
        IOptions<MvcJsonOptions> mvcOptions = testServer.Host.Services.GetService<IOptions<MvcJsonOptions>>();
        mvcSerializerSettings = mvcOptions.Value.SerializerSettings;
        ISwaggerProvider swaggerProvider = testServer.Host.Services.GetService<ISwaggerProvider>();
        document = swaggerProvider.GetSwagger(_documentName);
    }
    // Reference: Swashbuckle.AspNetCore.Swagger/Application/SwaggerSerializerFactory.cs
    var settings = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        Formatting = mvcSerializerSettings.Formatting,
        ContractResolver = new SwaggerContractResolver(mvcSerializerSettings),
    };
    string json = JsonConvert.SerializeObject(document, settings);
