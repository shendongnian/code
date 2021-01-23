    public class MyExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var ex = context.Exception as IRecordNotFoundException;
            if (ex != null)
            {
                context.Result = new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = $"{ex.EntityName} not found" });
            }
        }
    }
