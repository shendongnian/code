    public class ErrorStatusCodeHandler : IStatusCodeHandler
    {
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.InternalServerError;
        }
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            object errorObject;
            if (context.Items.TryGetValue(NancyEngine.ERROR_EXCEPTION, out errorObject))
            {
                var exception = errorObject as Exception;
                if (exception != null)
                {
                    throw exception;
                }
            }
        }
    }
