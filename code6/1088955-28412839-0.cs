    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        { }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpContext.Current.Items["CustomVariable"] = Guid.NewGuid();
        }
    }       
