    public class ApplicationModerator : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new namespace1.TierApplication1();
            new namespace2.TierApplication2();
            new namespace3.TierApplication3();
        }
    }
