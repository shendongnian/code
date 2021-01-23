    public class MyServices : Service
    {
        public object Any(MyRequest request)
        {
            var aspReq = base.Request.OriginalRequest as HttpRequestBase;
            if (aspReq != null)
            {
                var value = aspReq.RequestContext.HttpContext.Session["key"];
            }
            //or if you prefer via the ASP.NET Singleton:
            var value = HttpContext.Current.Session["key"];
        }
    }
