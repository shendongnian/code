    public class CustomErrorResult : IHttpActionResult
    {
        private readonly string _errorMessage;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;
    
        public CustomErrorResult(HttpRequestMessage requestMessage, 
           HttpStatusCode statusCode, string errorMessage)
        {
            _requestMessage = requestMessage;
            _statusCode = statusCode;
            _errorMessage = errorMessage;
        }
    
        public Task<HttpResponseMessage> ExecuteAsync(
           CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(
                _statusCode, _errorMessage));
        }
    }
