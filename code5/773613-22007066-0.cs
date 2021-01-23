      public static class RouteCollectionExtensions
        {
           
            public static VirtualPathData GetVirtualPathForArea(this RouteCollection routes, RequestContext requestContext, RouteValueDictionary values);
           
            public static VirtualPathData GetVirtualPathForArea(this RouteCollection routes, RequestContext requestContext, string name, RouteValueDictionary values);
           
            public static void IgnoreRoute(this RouteCollection routes, string url);
           
            public static void IgnoreRoute(this RouteCollection routes, string url, object constraints);
           
            public static Route MapRoute(this RouteCollection routes, string name, string url);
           
            public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults);
           
            public static Route MapRoute(this RouteCollection routes, string name, string url, string[] namespaces);
           
            public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints);
           namespaces.
           
            public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces);
           
            public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces);
        }
