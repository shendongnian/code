    public class MyExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by the Web API controller."),
                ReasonPhrase = "An unhandled exception was thrown by the Web API controller."
            };
            context.Response = msg;
        }
    }
