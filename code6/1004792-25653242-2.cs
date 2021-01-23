    using System;
    using System.Drawing;
    using System.Globalization;
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
                var id = context.Request["id"];
                var iId = 0;
                if (id != null && int.TryParse(id.ToString(CultureInfo.InvariantCulture), out iId))
                {
                    try
                    {
                        RespondForId(iId, context);
                    }
                    catch (Exception)
                    {
                        ErrorResponse(context);
                    }
                }
                else
                {
                    DefaultResponse(context);
                }
            }
    
            private static void DefaultResponse(HttpContext context)
            {
                var tt = File.ReadAllBytes(context.Server.MapPath("~/noId.jpg"));
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(tt);
            }
    
            private static void ErrorResponse(HttpContext context)
            {
                var tt = File.ReadAllBytes(context.Server.MapPath("~/error.jpg"));
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(tt);
            }
    
            private void RespondForId(int id, HttpContext context)
            {
                var tt = GetImageBytesForId(id); //File.ReadAllBytes(context.Server.MapPath("~/multcust.png"));
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(tt);
            }
    
            private static byte[] GetImageBytesForId(int id)
            {
                var b = new Bitmap(200, 200);
                byte[] retBytes;
                using (var g = Graphics.FromImage(b))
                {
                    g.DrawRectangle(Pens.BurlyWood, 1, 1, 198, 198);
                    using (var arialFontLarge = new Font("Arial", 20))
                    {
                        g.DrawString(id.ToString(CultureInfo.InvariantCulture), arialFontLarge, Brushes.Black, 5, 100);
                    }
    
                    using (var arialFontSmall = new Font("Arial", 10))
                    {
                        g.DrawString(string.Format("{0:yyyyMMdd hhmmssffff}", DateTime.Now), arialFontSmall, Brushes.Black, 5, 5);
                    }
                    var converter = new ImageConverter();
                    retBytes = (byte[])converter.ConvertTo(b, typeof(byte[]));
                }
                return retBytes;
            }
    
            public bool IsReusable
            {
                get { return false; }
            }
        }
    }
