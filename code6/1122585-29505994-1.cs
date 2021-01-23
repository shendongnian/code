    public class User : IHttpHandler
    {
      public void ProcessRequest(HttpContext context)
      {
         HttpResponse objResponse = context.Response;
         objResponse.Write("JSONString");
      }
      public bool IsReusable
      {
        get
        {
            return false;
        }
      }
    }
