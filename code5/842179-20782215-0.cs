    public class DownloadFileHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //get parameters
            string str = context.Request.QueryString["param1"];
            //process parameters received
            // set content type
            context.Response.ContentType = "text/xml";
            //send FILE in response
            context.Response.WriteFile(@"C:\Users\Xyz\Desktop\xyz.xml");
        }
        public bool IsReusable
        {
            get { return true; }
        }
    }
