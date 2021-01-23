    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CustomException)
            {
                var e = (CustomException)context.Exception;
                string message = context.Exception.Message;
                var response = context.Request.CreateErrorResponse(e.StatusCode.Conflict, new ODataError
                {
                    ErrorCode = e.StatusCodeString,
                    Message = message,
                    MessageLanguage = e.MessageLanguage
                });
                context.Response = response;
            }
            else
                base.OnException(context);
        }
    }
