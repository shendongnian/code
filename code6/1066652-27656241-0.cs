        public class Route : IHttpModule
       {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += delegate
            {
                //URL Rewriting 
                //---To remove the .svc extension service file name from URL----
                 HttpContext cxt = HttpContext.Current;
                string path = cxt.Request.AppRelativeCurrentExecutionFilePath;
                {
                    cxt.RewritePath(path.Insert(1, "/ReportingService.svc"), false);
                }
                
            };
        }
    }
