	public Route MapRoute(string name, string url, object defaults, object constraints, string[] namespaces)
	{
		if (namespaces == null && this.Namespaces != null)
		{
			namespaces = this.Namespaces.ToArray<string>();
		}
		Route route = this.Routes.MapRoute(name, url, defaults, constraints, namespaces);
		route.DataTokens["area"] = this.AreaName; // *** HERE! ***
		bool flag = namespaces == null || namespaces.Length == 0;
		route.DataTokens["UseNamespaceFallback"] = flag;
		return route;
	}
