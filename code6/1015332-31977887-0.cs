	public class Startup
	{
		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
		public static string PublicClientId { get; private set; }
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			ConfigureWebApi(config);
			ConfigureAuth(app);
			app.UseWebApi(config);
		}
        ...
	}
