    public class   ImageHandler:IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
    
      public void ProcessRequest (HttpContext context) {
        //Checking whether the imagebytes variable have anything else not doin anything
        if ((context.Session["ImageBytes"]) != null)
        {
            byte[] image = (byte[])(context.Session["ImageBytes"]);
            context.Response.ContentType = "image/JPEG";
            context.Response.BinaryWrite(image);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    }
