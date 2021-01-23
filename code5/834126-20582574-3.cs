    namespace YourNamespace
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                //Here your SignalR dependency resolver
                GlobalHost.DependencyResolver = new SignalrDefaultDependencyResolver(UnityConfig.Container);
    
                //other settings goes on
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
    
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
        }
    }
