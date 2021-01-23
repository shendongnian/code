    public class ElmahErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(
            System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); // WebApi
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Configure(System.Web.Http.GlobalConfiguration.Configuration);
        }
        private void Configure(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Filters.Add(
                new ElmahErrorAttribute()
            );
        }
    }
