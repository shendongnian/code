    public class XmlRpcRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            //The route will only be a match when requesting the url ~/XmlRpc, and in that case the MetaWeblogRouteHandler will handle the request
            if (httpContext.Request.AppRelativeCurrentExecutionFilePath.Equals("~/XmlRpc", StringComparison.CurrentCultureIgnoreCase))
                return new RouteData(this, new MetaWeblogRouteHandler());
            //If url is other than /XmlRpc, return null so MVC keeps looking at the other routes
            return null;
        }
        
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {            
            //return null, so this route is skipped by MVC when generating outgoing Urls (as in @Url.Action and @Html.ActionLink)
            return null;
        }
    }
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //Add the route using our custom XmlRpcRoute class
        routes.Add("XmlRpc", new XmlRpcRoute());
        ... your other routes ...
    }
