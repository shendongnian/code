    public class HandleExceptionFilter : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            responseMessage.Content = new StringContent(context.Exception.Message);
    
            context.Response = responseMessage;
        }
    }
