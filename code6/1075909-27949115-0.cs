    <%@ WebHandler Language="C#" Class="Handler" %>
    using System;
    using System.Web;
    public class Handler : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/javascript";
            context.Response.Write("alert('"+context.Request.UrlReferrer+"');\n");
        }
 
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
