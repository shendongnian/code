    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
    	RegisterCustomControllerFactory ();
        }
    }
    private void RegisterCustomControllerFactory ()
    {
        IControllerFactory factory = new CustomControllerFactory();
        ControllerBuilder.Current.SetControllerFactory(factory);
    }
