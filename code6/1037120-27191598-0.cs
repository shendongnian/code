    protected void Application_Start()
    {
    	AreaRegistration.RegisterAllAreas();
    	GlobalConfiguration.Configure(config =>
    	{
    		ODataConfig.Register(config); //this has to be before WebApi
    		WebApiConfig.Register(config); 
    	});
    	FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    	RouteConfig.RegisterRoutes(RouteTable.Routes);
    }
