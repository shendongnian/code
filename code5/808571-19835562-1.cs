    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            base.BeginRequest += OnBeginRequest;
        }
        private void OnBeginRequest(object sender, EventArgs e)
        {
            if (Request.RawUrl.Contains("product.aspx"))
            {
                //execute your business here..
            }
        }
