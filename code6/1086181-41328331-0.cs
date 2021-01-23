      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         GlobalConfiguration.Configure(MyApiProjectNamespace.WebApiConfig.Register);
      }
