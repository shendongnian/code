     <img src="/imagehandler.ashx" />
   
     public class ImageHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                byte[] buffer = imageToByteArray();
                context.Response.OutputStream.Write(buffer , 0, buffer .Length);
                context.Response.ContentType = "image/JPEG";
            }
        }
