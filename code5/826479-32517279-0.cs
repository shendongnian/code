    public class CustomHeaderAttribute : FilterAttribute, IActionFilter, IExceptionFilter
    {
        private static string HEADER_KEY   { get { return "X-CustomHeader"; } }
        private static string HEADER_VALUE { get { return "Custom header value"; } }
        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            return (new CustomHeaderAction() as IActionFilter).ExecuteActionFilterAsync(actionContext, cancellationToken, continuation);
        }
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return (new CustomHeaderException() as IExceptionFilter).ExecuteExceptionFilterAsync(actionExecutedContext, cancellationToken);
        }
        private class CustomHeaderAction: ActionFilterAttribute
        {
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                if (actionExecutedContext.Response != null)
                { 
                    actionExecutedContext.Response.Content.Headers.Add(HEADER_KEY, HEADER_VALUE);
                }
            }
        }
        private class CustomHeaderException : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                if (context.Response == null)
                {
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, context.Exception);
                }
                context.Response.Content.Headers.Add(HEADER_KEY, HEADER_VALUE);
            }
        }
    }
