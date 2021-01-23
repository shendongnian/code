    /// <summary>
    /// Dependency Injection abstraction for rest clients. 
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Adapter for serialization/deserialization of http body data
        /// </summary>
        ISerializationAdapter SerializationAdapter { get; }
        /// <summary>
        /// Sends a strongly typed request to the server and waits for a strongly typed response
        /// </summary>
        /// <typeparam name="TResponseBody">The expected type of the response body</typeparam>
        /// <typeparam name="TRequestBody">The type of the request body if specified</typeparam>
        /// <param name="request">The request that will be translated to a http request</param>
        /// <returns></returns>
        Task<Response<TResponseBody>> SendAsync<TResponseBody, TRequestBody>(Request<TRequestBody> request);
        /// <summary>
        /// Default headers to be sent with http requests
        /// </summary>
        IHeadersCollection DefaultRequestHeaders { get; }
        /// <summary>
        /// Default timeout for http requests
        /// </summary>
        TimeSpan Timeout { get; set; }
        /// <summary>
        /// Base Uri for the client. Any resources specified on requests will be relative to this.
        /// </summary>
        Uri BaseUri { get; set; }
        /// <summary>
        /// Name of the client
        /// </summary>
        string Name { get; }
    }
    public class Request<TRequestBody>
    {
        #region Public Properties
        public IHeadersCollection Headers { get; }
        public Uri Resource { get; set; }
        public HttpRequestMethod HttpRequestMethod { get; set; }
        public TRequestBody Body { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public string CustomHttpRequestMethod { get; set; }
        #endregion
        public Request(Uri resource,
            TRequestBody body,
            IHeadersCollection headers,
            HttpRequestMethod httpRequestMethod,
            IClient client,
            CancellationToken cancellationToken)
        {
            Body = body;
            Headers = headers;
            Resource = resource;
            HttpRequestMethod = httpRequestMethod;
            CancellationToken = cancellationToken;
            if (Headers == null) Headers = new RequestHeadersCollection();
            var defaultRequestHeaders = client?.DefaultRequestHeaders;
            if (defaultRequestHeaders == null) return;
            foreach (var kvp in defaultRequestHeaders)
            {
                Headers.Add(kvp);
            }
        }
    }
    public abstract class Response<TResponseBody> : Response
    {
        #region Public Properties
        public virtual TResponseBody Body { get; }
        #endregion
        #region Constructors
        /// <summary>
        /// Only used for mocking or other inheritance
        /// </summary>
        protected Response() : base()
        {
        }
        protected Response(
        IHeadersCollection headersCollection,
        int statusCode,
        HttpRequestMethod httpRequestMethod,
        byte[] responseData,
        TResponseBody body,
        Uri requestUri
        ) : base(
            headersCollection,
            statusCode,
            httpRequestMethod,
            responseData,
            requestUri)
        {
            Body = body;
        }
        public static implicit operator TResponseBody(Response<TResponseBody> readResult)
        {
            return readResult.Body;
        }
        #endregion
    }
    public abstract class Response
    {
        #region Fields
        private readonly byte[] _responseData;
        #endregion
        #region Public Properties
        public virtual int StatusCode { get; }
        public virtual IHeadersCollection Headers { get; }
        public virtual HttpRequestMethod HttpRequestMethod { get; }
        public abstract bool IsSuccess { get; }
        public virtual Uri RequestUri { get; }
        #endregion
        #region Constructor
        /// <summary>
        /// Only used for mocking or other inheritance
        /// </summary>
        protected Response()
        {
        }
        protected Response
        (
        IHeadersCollection headersCollection,
        int statusCode,
        HttpRequestMethod httpRequestMethod,
        byte[] responseData,
        Uri requestUri
        )
        {
            StatusCode = statusCode;
            Headers = headersCollection;
            HttpRequestMethod = httpRequestMethod;
            RequestUri = requestUri;
            _responseData = responseData;
        }
        #endregion
        #region Public Methods
        public virtual byte[] GetResponseData()
        {
            return _responseData;
        }
        #endregion
    }
