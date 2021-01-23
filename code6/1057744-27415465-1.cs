    public class GlobalExceptionFilter : ExceptionFilterAttribute {
        public override void OnException(HttpActionExecutedContext context) {
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, 
                                                                   "Bad Request", 
                                                                   context.Exception);
                var httpError = (HttpError)((ObjectContent<HttpError>)context.Response.Content).Value;
                if (!httpError.ContainsKey("ExceptionType"))
                    httpError.Add("ExceptionType", context.Exception.GetType().FullName);
                if (!httpError.ContainsKey("ExceptionMessage"))
                    httpError.Add("ExceptionMessage", context.Exception.Message);
        } 
    }
