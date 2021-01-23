    public virtual void Register(RouteCollection routes)
    {
        var rt = string.Format("{0}/{{controller}}/{{id}}", UrlNameSpace);
        var nameSpace = this.GetType().Namespace;
        Logger.DebugFormat("Route Template: {0} in namespace {1}...", rt, nameSpace);
        var r = routes.MapHttpRoute(
            name: Name,
            routeTemplate: rt,
            defaults: new { id = RouteParameter.Optional, controller = "Default", @namespace = nameSpace }
            );
        r.DataTokens = r.DataTokens ?? new RouteValueDictionary();
        r.DataTokens["Namespaces"] = new[] { nameSpace };
        Logger.InfoFormat("Plugin '{0}' registered namespace '{1}'.", Name, nameSpace);
    }
