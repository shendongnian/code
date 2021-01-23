    using System.IO;
    using System.Web;
    
    namespace TestImageHandler
    {
        /// <summary>
        ///     Summary description for ImageHandler
        /// </summary>
        public class ImageHandler : IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                byte[] tt = File.ReadAllBytes(context.Server.MapPath("~/image.jpg"));
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(tt);
            }
    
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
