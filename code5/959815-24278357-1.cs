     public class ImageHandler : IHttpHandler
     {
        public void ProcessRequest(HttpContext context)
        {
            var imageId = QueryString.getValueOf("ID");
            var imagePath="";//calculate for database or xml file
            var originalImage = Image.FromFile (context.Server.MapPath(imagePath);
            originalImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);  
            context.Response.ContentType = "image/gif"; //or any type
         }
      }
