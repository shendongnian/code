    public class MvcApplication : System.Web.HttpApplication
    {
    	protected void Application_Start()
    	{
    		MyLib.Configure(this);
    	}
    }
