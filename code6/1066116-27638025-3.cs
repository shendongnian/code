    public class RemoveHeaderHeaderDictionary : IHeaderDictionary
    {
        readonly IHeaderDictionary _parent;
        readonly IEnumerable<string> _headersToRemove;
        /// <summary>
        /// Logger
        /// </summary>
        public ILogger Logger { get; private set; }
        /// <summary>
        /// Create an instance of <see cref="RemoveHeaderHeaderDictionary"/>
        /// </summary>
        /// <param name="parent">the <see cref="IHeaderDictionary"/> to decorate</param>
        /// <param name="headersToRemove">a list of unwanted header</param>
        /// <param name="loggerFactory">the logger factory to create logger</param>
        public RemoveHeaderHeaderDictionary(IHeaderDictionary parent, IEnumerable<string> headersToRemove, ILoggerFactory loggerFactory)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (headersToRemove == null)
                throw new ArgumentNullException("headersToRemove");
            if (loggerFactory == null)
                throw new ArgumentNullException("loggerFactory");
            Logger = loggerFactory.Create<RemoveHeaderHeaderDictionary>();
            _parent = parent;
            _headersToRemove = headersToRemove;
            foreach (var header in headersToRemove)
                parent.Remove(header);
        }
        bool IsAllowedHeader(string header)
        {
            var allowed = !_headersToRemove.Any(h => h == header);
            Logger.WriteInformation(string.Format("{0} is {1}", header, allowed ? "allowed" : "not allowed"));
            return allowed;
        }
        public string this[string key]
        {
            get
            {
                return _parent[key];
            }
            set
            {
                if (IsAllowedHeader(key))
                    _parent[key] = value;
            }
        }
