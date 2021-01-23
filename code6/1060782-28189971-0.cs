    public class CustomDirectRouteProvider : DefaultDirectRouteProvider
	{
		protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
		{
			var routePrefix =  base.GetRoutePrefix(controllerDescriptor);
			var controllerBaseType = controllerDescriptor.ControllerType.BaseType;
			if (controllerBaseType == typeof(BaseController))
			{
				//TODO: Check for extra slashes
				routePrefix = "api/{tenantid}/" + routePrefix;
			}
			return routePrefix;
		}
	}
