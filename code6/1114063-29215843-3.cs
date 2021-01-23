    public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                
            routes.MapRoute(
                name: "Localization",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"^[a-zA-Z]{2}$", controller = GetAllControllersAsRegex(), action = GetAllActionsAsRegex }
            );
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { controller = GetAllControllersAsRegex(), action = GetAllActionsAsRegex() }
            );
            routes.MapRoute(
            "NotFound",
            "{*url}",
            new { controller = "Error", action = "Error404" }
            );
            routes.MapMvcAttributeRoutes();
        }
        private static string GetAllControllersAsRegex() 
        { 
            var controllers = typeof(MvcApplication).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Controller))); 
            var controllerNames = controllers
                .Select(c => c.Name.Replace("Controller", "")); 
            return string.Format("({0})", string.Join("|", controllerNames)); 
        }
        private static string GetAllActionsAsRegex()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var actions = asm.GetTypes()
                            .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
                            .SelectMany(type => type.GetMethods())
                            .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                            .Select(x=>x.Name);
            return string.Format("({0})", string.Join("|", actions)); 
        }
    }
