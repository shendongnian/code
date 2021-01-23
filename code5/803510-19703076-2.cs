    // something.ashx.cs
    public class something : IHttpHandler, IRequiresSessionState {
        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(context.Session["data"]));
        }
        public bool IsReusable { get { return false; } }
    }
