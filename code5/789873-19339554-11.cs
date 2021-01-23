	public class MvcApplication : System.Web.HttpApplication
	{
        private static IWindsorContainer container;
		
        protected void Application_Start()
		{
			container = new WindsorContainer();
			container.Install(FromAssembly.This());
			
            //Set the controller builder to use our custom controller factory
            var controllerFactory = new WindsorControllerFactory(container);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}
        protected void Application_End()
        {
            container.Dispose();
        }
    }
