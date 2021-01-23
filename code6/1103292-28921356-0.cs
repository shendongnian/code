    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ...
        }
        // Main Event handler
        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //Context.CurrentNotification Is "AcquireRequestState"
            //Context.IsPostNotification Is "False"
        }
        // Post Event handler
        void Application_PostAcquireRequestState(object sender, EventArgs e)
        {
            //Context.CurrentNotification Is "AcquireRequestState"
            //Context.IsPostNotification Is "True"
        }
        ...
    }
