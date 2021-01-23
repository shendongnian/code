    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));
    }
