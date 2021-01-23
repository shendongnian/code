	var factory = DependencyResolver.Current.GetService<IControllerFactory>() ?? new DefaultControllerFactory();
	TestController controller = factory.CreateController(this.ControllerContext.RequestContext, "Test") as TestController;
	RouteData route = new RouteData();
	route.Values.Add("action", "Test"); // ActionName, but it not required
	ControllerContext newContext = new ControllerContext(new HttpContextWrapper(System.Web.HttpContext.Current), route, controller);
	controller.ControllerContext = newContext;
	ActionResult result = controller.Test();
