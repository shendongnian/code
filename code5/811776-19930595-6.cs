    public static void RegisterRoutes(RouteCollection routes)
    {
        //adding the {id} and setting is as optional so that you do not need to use it for every action
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
