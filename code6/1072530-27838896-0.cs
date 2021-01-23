    namespace RSSHandler
    {
        public class RSSCollection
        {
            public static void checkRSS()
            {
             ...
            }
        }
    }
    namespace RSSHandler
    {
        public class Global : System.Web.HttpApplication
        {
            protected void Application_Start(object sender, EventArgs e)
            {
              RSSHandler.App_Code.RSSCollection.checkRSS();
            }
        }
    }
