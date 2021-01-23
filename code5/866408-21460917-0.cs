    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //Get Id from somewhere
            //Get binary data
            
            context.Response.ContentType = "application/octet-stream";
            context.Response.BinaryWrite(bytes);
        }
    }
