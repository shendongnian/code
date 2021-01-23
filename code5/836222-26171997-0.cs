        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            // This is where it "should" be
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // The WebApi routes cannot be initialized here.
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
