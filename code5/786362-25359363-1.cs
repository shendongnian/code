    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Village", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcApplication1.Controllers" }
            );
        }
