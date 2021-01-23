    public class CustomControllerFactory : DefaultControllerFactory
    	{
    		private static IKernel ninjectKernel;
    		public CustomControllerFactory()
    		{
    			ninjectKernel = new StandardKernel();
    			AddBindings(ninjectKernel);
    		}
    
    		protected override IController GetControllerInstance
    			(System.Web.Routing.RequestContext requestContext, Type controllerType)
    		{
    			if (controllerType == null)
    			{
    				return (new Controllers.MessageController());
    			}
    			else
    			{
    				return ((IController)ninjectKernel.Get(controllerType));
    			}
    		}
    
    		public static void AddBindings(IKernel ninjectKernel)
    		{
    			Common.DependencyInjection.DependencyManager.GetDependencyInjections().ForEach(current =>
    			{
    				if (current.Abstract != null && current.Implementation != null)
    				{
    					ninjectKernel.Bind(current.Abstract).To(current.Implementation);
    				}
    			});
    
    			ninjectKernel.Bind<ICustomerRepository>().To(typeof(CustomerRepository));
    		}
    	}
