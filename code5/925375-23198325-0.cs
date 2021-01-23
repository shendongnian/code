    public class MyController : ApiController
    {
        public HttpResponseMessage MyWebMethod()
        {
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.Write([WRITE YOUR JSON HERE]);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
