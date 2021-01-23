	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            ModelBinders.Binders.Add(typeof(string), new StringBinder());
		}
    }
