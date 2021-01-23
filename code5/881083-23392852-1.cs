     [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
     public class ExceptionsHandler : ExceptionFilterAttribute
     {
        ...
        public override void OnException(HttpActionExecutedContext context)
        {
          ...
           context.Response = context.Request.CreateErrorResponse(httpStatusCode, response);
        }
     }
	
