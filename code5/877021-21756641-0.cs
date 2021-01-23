    public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			RouteTable.Routes.Add(new ServiceRoute("MultipleEndpointService/FirstEndpoint", new ServiceHostFactory(), typeof(MultipleEndpointService)));			
		}
	}
