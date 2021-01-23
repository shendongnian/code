	public class HelloWorldConstraint : IRouteConstraint
	{
		public bool Match(HttpContextBase httpContext, Route route,
			string parameterName, RouteValueDictionary values,
			RouteDirection routeDirection)
		{
			// Determine whether to accept the route for this request.
			var browser = BrowserDetector.Parse(httpContext.Request.UserAgent);
			if (browser == BrowserPlatform.Mobile)
			{
				return true;
			}
			return false;
		}
	}
