    using Ninject;
    using System;
    using System.Web.Mvc;
    
    namespace MyProject.Web.API.Factories
    {
    	public class NinjectControllerFactory : DefaultControllerFactory
    	{
    		public IKernel Kernel { get; private set; }
    
    		public NinjectControllerFactory(IKernel kernel)
    		{
    			this.Kernel = kernel;
    		}
    		
    		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    		{
    			IController controller = null;
    
    			if (controllerType != null)
    				controller = (IController)Kernel.Get(controllerType);
    
    			return controller; 
    		}
    	}
    }
