    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "fa_default",
            "fa/{controller}/{action}/{id}",
            new { action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "UI.Areas.fa.Controllers" }
        );
    }
