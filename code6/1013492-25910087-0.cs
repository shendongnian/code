    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
      routes.MapRoute("Customer", "{controller}/{action}/{objCustomer}",
            new {controller = "Customer", action = "CreateCustomer", objCustomer = UrlParameter.Optional});
    }
