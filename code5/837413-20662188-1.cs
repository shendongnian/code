    public class SeoFriendlyRoute : Route
    {
    	private readonly string[] _valuesToSeo;
    
    	public SeoFriendlyRoute(string url, RouteValueDictionary defaults, IEnumerable<string> valuesToSeo, RouteValueDictionary constraints = null, RouteValueDictionary dataTokens = null, IRouteHandler routeHandler = null)
    		: base(url, defaults, constraints ?? new RouteValueDictionary(), dataTokens ?? new RouteValueDictionary(), routeHandler ?? new MvcRouteHandler())
    	{
    		if (valuesToSeo == null) { throw new ArgumentNullException("valuesToSeo"); }
    		_valuesToSeo = valuesToSeo.ToArray();
    	}
    	public override RouteData GetRouteData(HttpContextBase httpContext)
    	{
    		var routeData = base.GetRouteData(httpContext);
    		if (routeData != null)
    		{
    			foreach (var key in _valuesToSeo)
    			{
    				if (routeData.Values.ContainsKey(key))
    				{
    					routeData.Values[key] = GetActualValue((string)routeData.Values[key]);
    				}
    			}
    		}
    		return routeData;
    	}
    	public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
    	{
    		var seoFriendyValues = new RouteValueDictionary(values);
    		foreach (var key in _valuesToSeo)
    		{
    			if (seoFriendyValues.ContainsKey(key))
    			{
    				seoFriendyValues[key] = GetSeoFriendlyValue((string)seoFriendyValues[key]);
    			}
    		}
    		return base.GetVirtualPath(requestContext, seoFriendyValues);
    	}
    
    	private string GetSeoFriendlyValue(string actualValue)
    	{
    		//your method
    		StringBuilder str = new StringBuilder();
    		for (int i = 0, len = actualValue.Length; i < len; i++)
    		{
    			if (i == 0)
    			{
    				str.Append(Char.ToLower(actualValue[i]));
    			}
    			else if (Char.IsUpper(actualValue[i]))
    			{
    				str.Append("-" + Char.ToLower(actualValue[i]));
    			}
    			else
    			{
    				str.Append(actualValue[i]);
    			}
    		}
    		return str.ToString();
    	}
    
    	private static string GetActualValue(string seoFriendlyValue)
    	{
    		//action name is not case sensitive
    		//one limitation is the dash can be anywhere but the action will still be resolved
    		// /my-jumbled-page-name is same as /myjumbled-pagename
    		return seoFriendlyValue.Replace("-", string.Empty); 
    	}
    }
