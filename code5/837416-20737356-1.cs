    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.Routes.Add("Example", new AreaSEOFriendlyRoute(
            areaName: "Examples",
            url: "examples/{action}/{id}",
            valuesToSeo: new string[] { "action", "controller" },
            defaults: new RouteValueDictionary(new { controller = "Examples", action = "InterestingPlaces", id = UrlParameter.Optional }))
        );
    }
