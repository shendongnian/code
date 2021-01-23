    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(Register);
        }
        public static void Register(HttpConfiguration config)
        {
            // Parse TimeSpan in ISO format (e.g. PT5M)
            config.Services.Insert(
                typeof(ModelBinderProvider), 0,
                new SimpleModelBinderProvider(typeof(TimeSpan), new IsoTimeSpanModelBinder()));
        }
    }
