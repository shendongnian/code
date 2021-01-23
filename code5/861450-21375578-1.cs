    protected void Application_Start()
    {   
       AreaRegistration.RegisterAllAreas();
       RegisterGlobalFilters(GlobalFilters.Filters);
       RegisterRoutes(RouteTable.Routes);
       //Register your View Engine Here.
       ViewEngines.Engines.Add(new MyViewEngine());
    }
