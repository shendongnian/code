    public class MyHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RawUrl.Contains("product.aspx"))
            {
                // may be you can execute your decorate business here
            }
        }
        public bool IsReusable { get { return false; } }
    }
