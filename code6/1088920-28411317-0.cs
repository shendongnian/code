    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            Tests.Test = "This is set";
        }
    }
    public static class Tests 
    {
        public static string Test { get; set; }
    }
