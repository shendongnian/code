    class MethodConstraint : IHttpRouteConstraint
    {
        public HttpMethod Method { get; private set; }
    
        public MethodConstraint(HttpMethod method)
        {
            Method = method;
        }
    
        public bool Match(HttpRequestMessage request,
                          IHttpRoute route,
                          string parameterName,
                          IDictionary<string, object> values,
                          HttpRouteDirection routeDirection)
        {
            return request.Method == Method;
        }
    }
