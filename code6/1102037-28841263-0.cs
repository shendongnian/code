    <%@ WebHandler Language="C#" Class="ImageFeeder" %>
    
    using System;
    using System.Drawing;
    using System.IO;
    using System.Web;
    
    public class ImageFeeder : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "image/png";
            context.Response.Clear();
            context.Response.BufferOutput = true;
    
            MemoryStream m = new MemoryStream();
            Image i = Image.FromFile(@"C:\Path\to\image.PNG");
            i.Save(m, System.Drawing.Imaging.ImageFormat.Png);
    
            context.Response.BinaryWrite(m.ToArray());
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
