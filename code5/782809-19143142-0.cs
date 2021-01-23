    using System;
    using System.Web;
     
    public class ImageHandler : IHttpHandler, IReadOnlySessionState
    {     
        public void ProcessRequest(HttpContext context)
        {
            // Query image data from database based on query string value.
            context.Response.BinaryWrite(YourImageByte);
        }
     
        public bool IsReusable {
            get { return false; }
        }
     
    }
    
    // Usage
    Image1.ImageUrl ="ImageHandler.ashx?id=5"
