    [OnException]
    public class HomeController { .... }   
    public class OnException: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is TimeoutException)
                return Request.CreateErrorResponse(HttpStatusCode.RequestTimeout, ex.Message);
            if (context.Exception is UnauthorizedAccessException )
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex.Message);
            if (context.Exception is Exception)    
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to process your request.");
        }
    }
