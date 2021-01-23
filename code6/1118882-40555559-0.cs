    public class CachedOkResult<T> : OkNegotiatedContentResult<T>
    {
        public CachedOkResult(T content, TimeSpan howLong, ApiController controller) : base(content, controller)
        {
            HowLong = howLong;
        }
        public CachedOkResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) 
        : base(content, contentNegotiator, request, formatters) { }
        public TimeSpan HowLong { get; private set; }
        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await base.ExecuteAsync(cancellationToken);
            response.Headers.CacheControl = new CacheControlHeaderValue() {
                Public = false,
                MaxAge = HowLong
            };
            return response;
        }
    }
