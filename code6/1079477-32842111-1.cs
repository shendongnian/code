 public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
              name: "contactus",
              url: "contactus",
              defaults: new { Controller = "Cms", action = "Index", id = (int)Common.CMSContactUs },
               namespaces: new[] { "QZero.Controllers" }
          );
            routes.MapRoute(
               name: "aboutus",
               url: "aboutus",
               defaults: new { Controller = "Cms", action = "Index", id = (int)Common.CMSAboutUs },
                namespaces: new[] { "QZero.Controllers" }
           );
            routes.MapRoute(
           name: "useragreement",
           url: "useragreement",
           defaults: new { Controller = "Cms", action = "Index", id = (int)Common.CMSUserAgreement },
            namespaces: new[] { "QZero.Controllers" }
       );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "QZero.Controllers" }
           );
        }
    }
