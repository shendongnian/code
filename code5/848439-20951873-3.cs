	public class ServiceRunner<T> : ServiceStack.ServiceHost.ServiceRunner<T>
	{
		public ServiceRunner(IAppHost appHost, ActionContext actionContext) : base(appHost, actionContext)
		{
		}
		public override object Execute(IRequestContext requestContext, object instance, T request)
		{
			// Check if the instance is of type MyServiceBaseWithEnversSupport
			var ms = instance as MyServiceBaseWithEnversSupport;
            // If the request is not using the MyServiceBaseWithEnversSupport, then allow it to run, as normal.
			if(ms == null)
				return base.Execute(requestContext, instance, request);
            // Access the Envers object, set using the Session Information
            ms.Envers.Username = ms.Session.Username;
			return base.Execute(requestContext, ms, request);
		}
	}
