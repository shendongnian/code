    using System;
    using System.Web;
    
    public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        HttpPostedFile MyFile=context.Request.Files["filetoupload"];
        if (MyFile.ContentLength > 0 && MyFile != null)
        {
            MyFile.SaveAs(context.Server.MapPath("Path/On/Server"));
        }
        context.Response.Write("Saved Successfully");
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }
