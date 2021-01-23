    public class MyStatusCodeHandler : IStatusCodeHandler
    {
        private readonly IResponseNegotiator _negotiator;
        public MyStatusCodeHandler(IResponseNegotiator negotiator)
        {
            _negotiator = negotiator;
        }
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var error = new { StatusCode = statusCode, Message = "Not Found" };
            context.Response = _negotiator.NegotiateResponse(error, context);
        }
    }
