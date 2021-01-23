	public class OrderCorrectionEnumRouteConstraint : IHttpRouteConstraint
	{
		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
		{
			// You can also try Enum.IsDefined, but docs say nothing as to
			// is it case sensitive or not.
			var response = Enum.GetNames(typeof(OrderCorrectionActionEnum)).Any(s = &gt; s.ToLowerInvariant() == values[parameterName].ToString().ToLowerInvariant());
			return response;
		}
		public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary&lt; string, object&gt; values, HttpRouteDirection routeDirection)
        {
			bool response = Enum.GetNames(typeof(BlockCorrectionActionEnum)).Any(s = &gt; s.ToLowerInvariant() == values[parameterName].ToString().ToLowerInvariant());
            return response;              
        }
	}
