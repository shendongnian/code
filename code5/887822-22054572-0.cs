    public class Handler : IHttpHandler {
      public bool IsReusable {
        get { return false; }
      }
      public void ProcessRequest(HttpContext context) {
        var realPath = Server.MapPath("a.png");
        context.Response.ContentType = "image/png";
        context.Response.WriteFile(realPath);
      }
    }
