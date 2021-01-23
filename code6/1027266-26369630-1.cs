    public class RedirectHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
              context.BeginRequest += new EventHandler(this.context_BeginRequest);
        }
    
        private void context_BeginRequest(object sender, EventArgs e)
        {
              HttpApplication application = (HttpApplication)sender;
              HttpContext context = application.Context;
    
              //check here context.Request for using request object 
              if(context.Request.FilePath.Contains("ControllerPath"))
              {
                   //do some extra work here to get the actual complete path
                   context.Response.Redirect(string.Format("http://www.new.com/{0}", Request.Url.AbsolutePath));
              }
        }
