    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CustomException)
            {
                var e = (CustomException)context.Exception;
                var response = context.Request.CreateErrorResponse(e.StatusCode, new ODataError
                {
                    ErrorCode = e.StatusCodeString,
                    Message = e.Message,
                    MessageLanguage = e.MessageLanguage
                });
                context.Response = response;
            }
            else
                base.OnException(context);
        }
    }
