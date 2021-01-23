    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddCors();
        services.ConfigureCors(o=> o.AddPolicy("AllowAll", p => p.AllowAnyOrigin()));
    }
