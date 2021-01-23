        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
    
            //Remove all view engine
            ViewEngines.Engines.Clear();
    
            //Add Custom view Engine Derived from Razor
            ViewEngines.Engines.Add(new CustomViewEngine());
        }
        
