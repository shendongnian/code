    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
        null, // object constraints
        new string[] { "Namespace.Application.Controllers" } // namespaces
    );
