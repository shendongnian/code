    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.Routes.Add("Example", new AreaSEOFriendlyRoute(
            areaName: "MyArea",
            url: "my-area/{action}/{id}",
            valuesToSeo: new string[] { "action", "controller" },
            defaults: new RouteValueDictionary(new { controller = "MyController", action = "MyDefaultPage", id = UrlParameter.Optional }))
        );
    }
