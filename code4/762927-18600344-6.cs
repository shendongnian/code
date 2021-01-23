    public class MyModule1 : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }
    
        public void Dispose() { }
    
        void context_BeginRequest(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext
                           .Current
                           .Request
                           .Url
                           .Authority
                           .Contains("foo.mydomain.com"))
            {
                string URL = 
                    (System.Web.HttpContext.Current.Request.Url.Scheme + "://" +
                    "foo.mydomain.com" + 
                    HttpContext.Current.Request.Url.AbsolutePath + 
                    HttpContext.Current.Request.Url.Query);
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.StatusCode = 301;
                System.Web.HttpContext.Current.Response.Status 
                                                        = "301 Moved Permanently";
                System.Web.HttpContext.Current.Response.RedirectLocation = URL;
                System.Web.HttpContext.Current.Response.End();
            }
        }
    }
