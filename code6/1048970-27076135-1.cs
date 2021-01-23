    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;
     
        public JsonContentNegotiator(JsonMediaTypeFormatter formatter) 
        {
            _jsonFormatter = formatter;    
        }
     
        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
    // in app_start:
    
    var jsonFormatter = new JsonMediaTypeFormatter();
    config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
