     public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
             ....
             //Create timer
             DeleteEmployerTimer.StartTimer();
        }
    }
 
