    public class MyHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var siteId = Convert.ToInt16(context.Request.RequestContext.RouteData.Values["CurrentSiteId"]);
        }
    }
