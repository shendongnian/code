    public IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
    {
        /// rest of the code
    
        serviceCollection.Configure(RouteOptions>(routeOptions =>
        {
            routeOptions =>
                routeOptions.ConstraintMap
                .Add("yourstring", typeof(YourConstraintType)));
        }
    }
