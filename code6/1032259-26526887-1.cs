    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Filters.Add(new WebAPIExceptionsDemo.MyExceptionFilter());
            AreaRegistration.RegisterAllAreas();
            ...
        }
    }
