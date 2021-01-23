    public class RouteConfig
    {
      public static void RegisterRoutes(RouteCollection routes)
      {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
          name: "MyShortUrl",
          url: "MyShortUrl",
          defaults: new { controller = "Employee", action = "Edit", id = UrlParameter.Optional }
        );
        routes.MapRoute(
          name: "Default",
          url: "{controller}/{action}/{id}",
          defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
      }
    }
