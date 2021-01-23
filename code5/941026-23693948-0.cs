    public class MyImageHandler : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
    	// Comment out these lines first:
    	// context.Response.ContentType = "text/plain";
    	// context.Response.Write("Hello World");
    
    	context.Response.ContentType = "image/png";
    
    	var filepath = @"E:\your_image_dir\" + Request.QueryString["filename"];
    
    	//Ensure you have permissions else the below line will throw exception.
    	context.Response.WriteFile(filepath);
    	
        }
    
        public bool IsReusable {
    	get {
    	    return false;
    	}
        }
    }
