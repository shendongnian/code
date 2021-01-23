    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddCors();
        services.AddMvc();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        app.UseCors(builder =>  builder
        .AllowAnyOrigin());
        app.UseMvc();
    }
