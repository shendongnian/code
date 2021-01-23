    class GetRouteAttribute : MethodConstraintedRouteAttribute
    {
        public GetRouteAttribute(string template) : base(template ?? "", HttpMethod.Get) { }
    }
    
    class PostRouteAttribute : MethodConstraintedRouteAttribute
    {
        public PostRouteAttribute(string template) : base(template ?? "", HttpMethod.Post) { }
    }
