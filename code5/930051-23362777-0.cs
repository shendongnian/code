        private string _controllerName;
        public ReWriteUrlRouteHandler(string controllerName)
        {
            _controllerName = controllerName;
        }
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var routeValues = requestContext.RouteData.Values;
            var id = routeValues["id"];
            var action = routeValues["action"];
            var task = routeValues["task"];
            var defaultAction = string.Format("{0}{1}", task, action);
            //translate to default handler
            requestContext.RouteData.Values["controller"] = _controllerName;
            requestContext.RouteData.Values["action"] = defaultAction;
            requestContext.RouteData.Values["id"] = id;
           
            return new MvcHandler(requestContext);
        }
    }
