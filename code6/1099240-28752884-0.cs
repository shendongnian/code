    public class FilteredRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData result = null;
			var path = httpContext.Request.Path;
            // Path always starts with a "/", so ignore it.
			var segments = path.Substring(1).Split('/');
			
			if (segments.Any() && segments[0].Equals("FilteredResults", StringComparison.OrdinalIgnoreCase))
			{
				var result = new RouteData(this, new MvcRouteHandler());
				result.Values["controller"] = "Filter";
				result.Values["action"] = "ProcessFilters";
				
				// Add filters to route data (skip the first segment)
				var filters = segments.Skip(1).ToArray();
				
				foreach (var filter in filters)
				{
					string key = ParseRouteKey(filter);
					var value = ParseRouteValue(filter);
					
					result.Values[key] = value;
				}
			}
			
			// Make sure to return null if this route does not match
			return result;
		}
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData result = null;
            
			// Process outgoing route here (to rebuild the URL from @Html.ActionLink)
			
            return result;
        }
    }
