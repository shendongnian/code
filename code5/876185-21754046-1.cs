    public class DownloadFileHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            Response.BinaryWrite(...);
        }
    }
