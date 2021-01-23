    public class JsonErrorStatusCodeHandler : IStatusCodeHandler
    {
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            if (statusCode != HttpStatusCode.InternalServerError)
            {
                return false;
            }
            var exception = context.GetException();
            return exception != null;
        }
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var exception = context.GetException();
            JsonResponse response = new JsonResponse(string.Format("{0}:{1}", exception, exception.Message), new DefaultJsonSerializer());
            response.StatusCode = HttpStatusCode.InternalServerError;
            context.Response = response;
            context.Response.WithHeader("Access-Control-Allow-Origin", "*")
                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
        }
    }
