    // First, in the Startup class for the application, we will add the required services. 
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
        });
    }
