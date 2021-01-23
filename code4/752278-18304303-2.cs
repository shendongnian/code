    routes.MapRoute(
        "CDN",
        "cdn",
        new { controller = "Webpage", action = "Fetch" }
    );
    [OutputCache(Duration=300, Location=OutputCacheLocation.Any)]
    public ActionResult Fetch()
    {
        return new FileStreamResult(
                           GetScriptBundle(Request.QueryString["url"]),
                           "text/javascript");
    }
