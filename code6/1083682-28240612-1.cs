    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // ...
            ControllerBuilder.Current.SetControllerFactory(typeof(CustomControllerFactory));
        }
        // ...
    }
