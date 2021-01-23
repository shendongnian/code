    routes.MapRoute(
        "Default",
        "{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        new[] { "My.Controllers" }
    );
    
    context.MapRoute(
        "Admin_default",
        "Admin/{controller}/{action}/{id}",
        new { action = "Index", id = UrlParameter.Optional },
        new[] { "My.Areas.Admin.Controllers" }
    );
