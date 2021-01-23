    public class ImageHandler : IHttpHandler 
    {
        public void ProcessRequest(HttpContext context)
        {
            // Grab ID from query string
            int id = Convert.ToInt32(context.Request.QueryString["roomID"]);
        
            // Logic here to retrieve image from database
            // Write image to context object to return to browser
            // Set content type to type of image, change to whatever you need it to be
            context.Response.ContentType = "image/gif";
        }
        public bool IsReusable 
        {
            get {
                return false;
            }
        }
    }
