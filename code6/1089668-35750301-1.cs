    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(
            options => 
            {
                options.Conventions.Add(new ApiExplorerVisibilityEnabledConvention());
                options.
            }
    }
