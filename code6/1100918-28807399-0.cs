       public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
          if (routes == null)
            throw new ArgumentNullException("routes");
          if (url == null)
            throw new ArgumentNullException("url");
          Route route = new Route(url, (IRouteHandler) new MvcRouteHandler())
          {
            Defaults = RouteCollectionExtensions.CreateRouteValueDictionaryUncached(defaults),
            Constraints = RouteCollectionExtensions.CreateRouteValueDictionaryUncached(constraints),
            DataTokens = new RouteValueDictionary()
          };
          ConstraintValidation.Validate(route);
          if (namespaces != null && namespaces.Length > 0)
            route.DataTokens["Namespaces"] = (object) namespaces;
          routes.Add(name, (RouteBase) route);
          return route;
        }
