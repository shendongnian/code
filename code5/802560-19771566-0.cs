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
                else
                    context.Response.StatusCode = 405;
                context.Response.End();
            }
        }
    }
