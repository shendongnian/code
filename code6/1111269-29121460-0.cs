    public Route MapRoute(string name, string url, object defaults, object constraints, string[] namespaces)
    {
      if (namespaces == null && this.Namespaces != null)
        namespaces = Enumerable.ToArray<string>((IEnumerable<string>) this.Namespaces);
      Route route = RouteCollectionExtensions.MapRoute(this.Routes, name, url, defaults, constraints, namespaces);
      route.DataTokens["area"] = (object) this.AreaName; // ** HERE **
      bool flag = namespaces == null || namespaces.Length == 0;
      route.DataTokens["UseNamespaceFallback"] = (object) (bool) (flag ? 1 : 0);
      return route;
    }
