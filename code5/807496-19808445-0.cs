    public sealed class CachingQueryHandlerDecorator<TQuery, TResult>
        : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private static readonly bool shouldCache;
        private static readonly CachingPolicySettings policy;
        private readonly IQueryHandler<TQuery, TResult> _handler;
        private readonly ObjectCache _cache;
        private readonly ILog _log;
        static CachingQueryHandlerDecorator()
        {
            var attribute = typeof(TQuery).GetCustomAttribute<CachePolicyAttribute>();
            if (attribute != null)
            {
                shouldCache = true;
                policy = attribute.Policy;
            }
        }
        public CachingQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> handler,
            ObjectCache cache,
            ILog log)
        {
            _handler = handler;
            _cache = cache;
            _log = log;
        }
        public TResult Handle(TQuery query)
        {
            if (!shouldCache)
            {
                return this._handler.handle(query);
            }
            // do your caching stuff here.
        }
