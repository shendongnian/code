    protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
    {
      // Get the calling controller's route prefix
      var routePrefix = base.GetRoutePrefix(controllerDescriptor);
      // Iterate through each of the calling controller's base classes that inherit from HttpController
      var baseControllerType = controllerDescriptor.ControllerType.BaseType;
      while(typeof(IHttpController).IsAssignableFrom(baseControllerType))
      {
        // Get the base controller's route prefix, if it exists
        // GOTCHA: There are two RoutePrefixAttributes... System.Web.Http.RoutePrefixAttribute and System.Web.Mvc.RoutePrefixAttribute!
        //  Depending on your controller implementation, either one or the other might be used... checking against typeof(RoutePrefixAttribute) 
        //  without identifying which one will sometimes succeed, sometimes fail.
        //  Since this implementation is generic, I'm handling both cases.  Preference would be to extend System.Web.Mvc and System.Web.Http
        var baseRoutePrefix = Attribute.GetCustomAttribute(baseControllerType, typeof(System.Web.Http.RoutePrefixAttribute)) 
          ?? Attribute.GetCustomAttribute(baseControllerType, typeof(System.Web.Mvc.RoutePrefixAttribute));
        if (baseRoutePrefix != null)
        {
          // A trailing slash is added by the system. Only add it if we're prefixing an existing string
          var trailingSlash = string.IsNullOrEmpty(routePrefix) ? "" : "/";
          // Prepend the base controller's prefix
          routePrefix = ((RoutePrefixAttribute)baseRoutePrefix).Prefix + trailingSlash + routePrefix;
        }
        // Traverse up the base hierarchy to check for all inherited prefixes
        baseControllerType = baseControllerType.BaseType;
      }
      return routePrefix;
    }
