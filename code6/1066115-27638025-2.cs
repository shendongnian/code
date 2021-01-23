    public class RemoveHeaderHttpResponse : HttpResponse
    {
        readonly HttpResponse _parent;
        readonly HttpContext _context;
        readonly IHeaderDictionary _headers;
        /// <summary>
        /// Create instance of <see cref="RemoveHeaderHttpResponse"/>
        /// </summary>
        /// <param name="context">the <see cref="HttpContext"/> associated to the HTTP respone</param>
        /// <param name="parent">the <see cref="HttpResponse"/> to decorate</param>
        /// <param name="headersToRemove">a list of unwanted header</param>
        /// <param name="loggerFactory">the logger factory to create logger</param>
        public RemoveHeaderHttpResponse(HttpContext context, HttpResponse parent, IEnumerable<string> headersToRemove, ILoggerFactory loggerFactory)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (headersToRemove == null)
                throw new ArgumentNullException("headersToRemove");
            if (loggerFactory == null)
                throw new ArgumentNullException("loggerFactory");
            _parent = parent;
            _context = context;
            _headers = new RemoveHeaderHeaderDictionary(parent.Headers, headersToRemove, loggerFactory);
        }
        public override IHeaderDictionary Headers
        {
            get
            {
                return _headers;
            }
        }
