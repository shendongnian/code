    public class CustomOkResult<T> : OkNegotiatedContentResult<T>
    {
        public CustomOkResult(T content, ApiController controller)
            : base(content, controller) { }
    
        public CustomOkResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) 
            : base(content, contentNegotiator, request, formatters) { }
    
        public string ETagValue { get; set; }
    
        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);
    
            response.Headers.ETag = new EntityTagHeaderValue(this.ETagValue);
    
            return response;
        }        
    }
