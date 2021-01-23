	/// <summary>
	/// Controller factory the class is to be used to eliminate hard-coded dependencies 
	/// between controllers and other components
	/// </summary>
	public class ControllerFactory : DefaultControllerFactory
	{
        private readonly IWindsorContainer container;
 
        public WindsorControllerFactory(IKernel container)
        {
            this.container = container;
        }
		public override void ReleaseController(IController controller)
		{
			container.Release(controller.GetType());
		}
		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			return (IController)container.Resolve(controllerType);
		}
	}
  
