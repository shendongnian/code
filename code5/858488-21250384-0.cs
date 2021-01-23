    public class HttpNotFoundActionDescriptor : ReflectedHttpActionDescriptor
    {
        ReflectedHttpActionDescriptor _descriptor;
        public HttpNotFoundActionDescriptor(ReflectedHttpActionDescriptor descriptor)
        {
    	_descriptor = descriptor;
        }
    
        public override Task<object> ExecuteAsync(HttpControllerContext controllerContext, IDictionary<string, object> arguments, CancellationToken cancellationToken)
        {
    	try
            {
                return descriptor.ExecuteAsync(controllerContext, arguments, cancellationToken);
            }
            catch (HttpResponseException ex)
            {
    	     //..........................
    	}	
        }
    }
    
    public class HttpNotFoundAwareControllerActionSelector : ApiControllerActionSelector
    {
        public HttpNotFoundAwareControllerActionSelector()
        {
        }
    
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            HttpActionDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectAction(controllerContext);
            }
            catch (HttpResponseException ex)
            {
                var code = ex.Response.StatusCode;
                if (code != HttpStatusCode.NotFound && code != HttpStatusCode.MethodNotAllowed)
                    throw;
                var routeData = controllerContext.RouteData;
                routeData.Values["action"] = "Handle404";
                IHttpController httpController = new ErrorController();
                controllerContext.Controller = httpController;
                controllerContext.ControllerDescriptor = new HttpControllerDescriptor(controllerContext.Configuration, "Error", httpController.GetType());
                decriptor = base.SelectAction(controllerContext);
            }
            return new HttpNotFoundActionDescriptor(decriptor);
        }
    }
