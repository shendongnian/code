    public class Handler1 : IHttpHandler
    {
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write(true); // this return value was changing manually
                                      // to test both true and false situations
        context.Response.End();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    }
