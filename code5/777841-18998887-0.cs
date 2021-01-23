    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            // Load the image (see previous code sample)
            byte[] data = Convert.FromBase64String(encodedString);
    
            // Display the image
            context.Response.OutputStream.Write(data, 0, data.Length);
            context.Response.ContentType = "image/JPEG";
        }
    }
