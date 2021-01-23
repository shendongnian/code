	public sealed class StartupConfig {
		public void Configuration(
			IAppBuilder app) {
			this.ConfigureAuthentication(app);
		}
		public void ConfigureAuthentication(
			IAppBuilder app) {
			app.UseCookieAuthentication(new CookieAuthenticationOptions {
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/"),
				ExpireTimeSpan = new TimeSpan(0, 60, 0)
			});
		}
	}
