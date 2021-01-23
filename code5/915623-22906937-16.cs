    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(
                new CompositionRoot());
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            CompositionRoot.CleanUpRequest();
        }
    }
