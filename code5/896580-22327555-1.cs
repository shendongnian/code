    routes.MapRoute(
        "SpecialControllerName",
        "CustomName/{*id}",
         new { controller = "CustomName", action = "CustomAction", id = UrlParameter.Optional }
    );
    public ActionResult Name(string id)
    {
      //logic goes here
    }
