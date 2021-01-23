    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {
                ODataConfig.Register(config); 
                WebApiConfig.Register(config);
            });            
        }
    }
