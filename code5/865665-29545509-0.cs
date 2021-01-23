    public class FlexibleNegotiatedContentResult<T> : NegotiatedContentResult<T>
    {
        private readonly Action<HttpResponseMessage> _responseMessageDelegate;
    
        public FlexibleNegotiatedContentResult(HttpStatusCode statusCode, T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
            : base(statusCode, content, contentNegotiator, request, formatters)
        {
        }
    
        public FlexibleNegotiatedContentResult(HttpStatusCode statusCode, T content, ApiController controller, Action<HttpResponseMessage> responseMessageDelegate = null)
            : base(statusCode, content, controller)
        {
            _responseMessageDelegate = responseMessageDelegate;
        }
    
        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage = await base.ExecuteAsync(cancellationToken);
    
            if (_responseMessageDelegate != null)
            {
                _responseMessageDelegate(responseMessage);
            }
    
            return responseMessage;
        }
    }
