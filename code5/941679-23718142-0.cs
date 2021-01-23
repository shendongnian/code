    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Manufacture_default",
            "Manufacture/{controller}/{action}/{id}/{tab}",
            new { action = "Index", id = UrlParameter.Optional, tab = UrlParameter.Optional }
        );
    }
