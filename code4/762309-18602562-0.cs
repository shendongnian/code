    public class DomainRouteConstraint : IRouteConstraint {
        string _host;
        public DomainRouteConstraint(string host) {
            _host = host;
        }
        public bool Match(HttpContextBase httpContext, 
                              Route route, 
                              string parameterName,        
                              RouteValueDictionary values, 
                              RouteDirection routeDirection) {
            return _host.Equals(httpContext.Request.Url.Host,
                                StringComparison.InvariantCultureIgnoreCase);
        }
    }
