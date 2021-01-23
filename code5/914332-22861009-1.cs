    public class keepalive : IHttpHandler, IRequiresSessionState {
        
        public void ProcessRequest (HttpContext context) {
            if (context.User.Identity.IsAuthenticated)
            {
                // authenticated sessions
                context.Response.ContentType = "text/plain";
                context.Response.Write("Auth:" + context.Session.SessionID);
            }
            else
            {
                // guest
                context.Response.ContentType = "text/plain";
                context.Response.Write("NoAuth:" + context.Session.SessionID);
            }
        }
