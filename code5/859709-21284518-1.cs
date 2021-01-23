    public class myHandler : IHttpHandler
    {
       public void ProcessRequest(HttpContext context)
        {
            string requestStr= new StreamReader(context.Request.InputStream).ReadToEnd();
            context.Response.ContentType = "application/text";
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    break;
                case "POST":
                    context.Response.Write("ok");
                    break;
                default:
                    break;
            }
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
