    namespace CustomHandlers
    {
        public class CORSOPTIONSVerbHandler : IHttpHandler
        {
            public bool IsReusable
            {
                get { return true; }
            }
    
            public void ProcessRequest(HttpContext context)
            {
                if (context.Response.HttpMethod == "OPTIONS")
                    context.Response.StatusCode = 200;
                    context.Response.Headers.Add("Access-Control-Allow-Headers" ,"x-user-session,origin, content-type, accept");
                else
                    context.Response.StatusCode = 405;
    
                context.Response.End();
            }
        }
    }
