	public static class RouteMappingConfig
	{
		static RouteMappingConfig () { RouteMappings = new List<RouteMapping>(); }
		public static List<RouteMapping> RouteMappings { get; set; }
	}
	public class RouteMapping
	{
		public class RouteMapping(string ctrl, string action, string method) { /*...*/ }
		public string Controller { get; set; }
		public string Action { get; set; }
		public string Method { get; set; }
	}
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
		    //set up mappings
			RouteMappingConfig.RouteMappings.Add(new RouteMapping("MyController", "MyAction", "MyMethod"));
			
			foreach(var mapping in RouteMappingConfig.RouteMappings)
			{
				routes.MapRoute(
					name: mapping.Controller + "_" + mapping.Action,
					url: "{controller}/{action}/",
					defaults: new { controller = mapping.Controller, action = mapping.Action }
				);
			}
		}
	}
    public class MyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
			var controllerName = routeData.Values["controller"];
			var actionName = routeData.Values["action"];
			
            //thanks @Andy Nichols
            var fullControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
			var mapping = RouteMappingConfig.RouteMappings.SingleOrDefault(x => x.Controller == controllerName && x.Action == actionName);
			string methodName = actionName;
			if(mapping != null)
			{
				methodName = mapping.Method;
			}
			
            foreach(var kvp in filterContext.ActionParameters)
                //log your params
        }
    }
	
