    public class CacheableJsonResult<T> : JsonResult<T>
    {
    	private readonly string _eTag;
    	private const int MaxAge = 10;	//10 seconds between requests so it doesn't even check the eTag!
    
    	public CacheableJsonResult(T content, JsonSerializerSettings serializerSettings, Encoding encoding, HttpRequestMessage request, string eTag)
    		:base(content, serializerSettings, encoding, request)
    	{
    		_eTag = eTag;
    	}
    
    	public override Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
    	{
    		Task<HttpResponseMessage> response = base.ExecuteAsync(cancellationToken);
    
    		return response.ContinueWith<HttpResponseMessage>((prior) =>
    		{
    			HttpResponseMessage message = prior.Result;
    
    			message.Headers.ETag = new EntityTagHeaderValue(String.Format("\"{0}\"", _eTag));
    			message.Headers.CacheControl = new CacheControlHeaderValue
    			{
    				Public = true,
    				MaxAge = TimeSpan.FromSeconds(MaxAge)
    			};
    
    			return message;
    		}, cancellationToken);
    	}
    }
        
