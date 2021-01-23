    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Web;
    
    namespace WebApp.ModalPopup
    {
        /// <summary>
        /// Summary description for image_loader
        /// </summary>
        public class image_loader : IHttpHandler
        {
    
            public void ProcessRequest(HttpContext context)
            {
                context.Response.ContentType = "image/jpg";
                var imagePath = context.Server.MapPath("~/images/windows_xp_bliss-wide.jpg");
                Thread.Sleep(20000);
                context.Response.TransmitFile(imagePath);
            }
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
