    public class NotFoundPlainTextActionResult : IHttpActionResult
    {
        public NotFoundPlainTextActionResult(HttpRequestMessage request, string message)
        {
            Request = request;
            Message = message;
        }
        public string Message { get; private set; }
        public HttpRequestMessage Request { get; private set; }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(ExecuteResult());
        }
        public HttpResponseMessage ExecuteResult()
        {
            var response = new HttpResponseMessage();
            if (!string.IsNullOrWhiteSpace(Message))
                //response.Content = new StringContent(Message);
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception(Message));
            response.RequestMessage = Request;
            return response;
        }
    }
