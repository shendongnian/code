    context.MapRoute(
        "Admin_Duplicate",
        "Admin/Duplicate/{action}/{id}",
        new { controller = "Duplicate", action = "Index", id = UrlParameter.Optional },
        new[] { "MyMvcApplication.Areas.Admin.Controllers" }
    );
