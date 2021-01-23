    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute("Test", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }
