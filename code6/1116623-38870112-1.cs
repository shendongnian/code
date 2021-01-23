    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped((_) => new ApplicationDbContext(Configuration["Data:DefaultConnection:ConnectionString"]));
    
        // Configure remaining services
    }
