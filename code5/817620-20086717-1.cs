        public class MvcApplication : System.Web.HttpApplication
    	{
    		private IKernel kernel = new StandardKernel();
    
    		protected void Application_Start()
    		{
    			    
    			AreaRegistration.RegisterAllAreas();
      			WebApiConfig.Register(GlobalConfiguration.Configuration);
    			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    			RouteConfig.RegisterRoutes(RouteTable.Routes);
    			BundleConfig.RegisterBundles(BundleTable.Bundles);
    
    			//register a cutom controller factory
    			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));   					
    			
    		}
    	}
