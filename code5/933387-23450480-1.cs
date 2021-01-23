    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "{id}",
            defaults: new { controller = "Home", action = "YourAction", id = UrlParameter.Optional }
            );
        }
    }
