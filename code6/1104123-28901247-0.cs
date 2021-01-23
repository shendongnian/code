public override void Initialize(System.Web.Routing.RequestContext requestContext)
{
    base.Initialize(requestContext);
    var customHost = ConfigurationManager.AppSettings["CustomHost"];
    string theme = String.Empty;
    if (customHost.ToLower().Contains(requestContext.HttpContext.Request.Url.Host.ToLower()))
    {
        ViewBag.Theme = "CustomTheme";
    }
    else
    {
        ViewBag.Theme = "DefaultTheme";
    }
}
