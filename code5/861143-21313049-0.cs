    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
 
        RegisterGlobalFilters(GlobalFilters.Filters);
        RegisterRoutes(RouteTable.Routes);
        RegisterDependencyResolver();
    }
 
    private void RegisterDependencyResolver()
    {
        var kernel = new StandardKernel();
        // you may need to configure your container here?
        RegisterServices(kernel);
 
        DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
    }
