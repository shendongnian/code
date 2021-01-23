    using AspNetCore.RouteAnalyzer; // Add
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddRouteAnalyzer(); // Add
    }
