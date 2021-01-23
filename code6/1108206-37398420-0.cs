    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        } }
