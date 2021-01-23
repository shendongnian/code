    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Setup DI
            Bootstrapper.Initialise();
    
           // other init
        }
    }
