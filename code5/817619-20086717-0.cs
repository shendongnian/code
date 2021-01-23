        public class NinjectControllerFactory : DefaultControllerFactory
    	{
    	
    		#region Member Variables
    
    		private IKernel ninjectKernel = null;
    
    		#endregion
    
    		public NinjectControllerFactory(IKernel kernel)
    		{
    			this.ninjectKernel = kernel;
    			AddBindings();
    		}
    
    		private void AddBindings()
    		{
    			//BO
    			ninjectKernel.Bind<IAuthenticationBO>().To<AuthenticationBO>();
    			
    			//DAO
    			ninjectKernel.Bind<ISharedDAO>().To<SharedDAO>();
    			
    		}
    		
    		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    		{
    			return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
    		}
    	}
