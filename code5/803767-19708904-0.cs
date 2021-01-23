    public class RemoveSlashRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.RouteData.Values["controller"] = ((string)requestContext.RouteData.Values["controller"]).Replace("-", String.Empty);
            return base.GetHttpHandler(requestContext);
        }
    }
