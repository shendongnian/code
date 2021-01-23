    public class NotFoundTextPlainActionResult : IHttpActionResult
    {
        public NotFoundTextPlainActionResult(string message, HttpRequestMessage request)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            Message = message;
            Request = request;
        }
        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Content = new StringContent(Message); // Put the message in the response body (text/plain content).
            response.RequestMessage = Request;
            return response;
        }
    }
    public static class ApiControllerExtensions
    {
        public static NotFoundTextPlainActionResult NotFound(this ApiController controller, string message)
        {
            return new NotFoundTextPlainActionResult(message, controller.Request);
        }
    }
