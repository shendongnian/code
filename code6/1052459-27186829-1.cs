    [assembly: OwinStartup(typeof(Startup), "Configuration")]    
    namespace YourNamespace
    {
    	public class Startup
    	{
    		public void Configuration(IAppBuilder app)
    		{
    			AuthConfig.RegisterAuth(app);
    		}
    	}
    }
