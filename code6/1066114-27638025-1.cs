    public class RemoveHeaderHttpContext : HttpContext
    {
        readonly HttpContext _parent;
        readonly HttpResponse _response;
        /// <summary>
        /// Create instance of <see cref="RemoveHeaderHttpContext"/>
        /// </summary>
        /// <param name="parent">the <see cref="HttpContext"/> to decorate/></param>
        /// <param name="headersToRemove">a list of unwanted header</param>
        /// <param name="loggerFactory">the logger factory to create logger</param>
        public RemoveHeaderHttpContext(HttpContext parent, IEnumerable<string> headersToRemove, ILoggerFactory loggerFactory)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (headersToRemove == null)
                throw new ArgumentNullException("headersToRemove");
            if (loggerFactory == null)
                throw new ArgumentNullException("loggerFactory");
            _parent = parent;
            _response = new RemoveHeaderHttpResponse(this, parent.Response, headersToRemove, loggerFactory);
        }
        public override HttpResponse Response
        {
            get
            {
                return _response;
            }
        }
