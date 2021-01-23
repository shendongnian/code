    using System;
    using System.Web;
    
    public class myKeepAliveUrl : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Session != null)
                context.Session["_reloadKey"] = Guid.NewGuid(); //do something with the session (not really needed)
            context.Response.StatusCode = 200;
            context.Response.Write("OK"); //write OK.. Not really needed
        }
    
        public bool IsReusable { get { return false; } }
    
    }
