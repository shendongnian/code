	public class UserRoute: Route
	{
		public UserRoute()
			: base("{controller}/{action}/{id}", new MvcRouteHandler())
		{
		}
		public override RouteData GetRouteData(HttpContextBase httpContext)
		{
			var rd = base.GetRouteData(httpContext);
			if (rd == null)
			{
				return null;
			}
            //You have access to HttpContext here as it's part of the request 
            //so this should be possible using whatever you need to auth the user. 
            //I.e session etc.
			if (httpContext.Current.Session["someSession"] == "something") 
			{
				rd.Values["controller"] = "Foo"; //Controller for this user
				rd.Values["action"] = "Index";
			}
			else
			{
				rd.Values["controller"] = "Bar"; //Controller for a different user.
				rd.Values["action"] = "Index";
			}
			
			rd.Values["id"] = rd.Values["id"]; //Pass the Id that came with the request. 
			
			return rd;
		}
	}
