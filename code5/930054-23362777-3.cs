    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        var programRoute = new Route("Program/{id}/{action}/{task}", new ReWriteUrlRouteHandler("Program"));//your new route with controller name
        routes.Add("ProgramRoute", programRoute);
        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
    }
:)
