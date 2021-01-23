	public partial class _Default : System.Web.UI.Page
	{
		private WebAuthorizer auth;
		private TwitterContext twitterCtx;
		protected void Page_Load(object sender, EventArgs e)
		{
			IOAuthCredentials credentials = new SessionStateCredentials();
			if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
			{
				credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
				credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
			}
			auth = new WebAuthorizer
			{
				Credentials = credentials,
				PerformRedirect = authUrl => Response.Redirect(authUrl)
			};
