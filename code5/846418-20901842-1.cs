    public class Handler : IHttpHandler, IRequiresSessionState
    {
        
        public void ProcessRequest (HttpContext context)
        {
    
            string sessionValue = context.Session["MailId"].ToString();
            context.Response.Write(sessionValue);
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
