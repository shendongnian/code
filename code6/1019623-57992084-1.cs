    public class RequestHandler
    {
        private readonly IQueryCache _cache;
        private readonly IRepository _repository;
    
        public RequestHandler(IRepository repository, IQueryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }
    
        public TResult GetResult(Guid userId)
        {
            var query = new Query() { UserId = userId };
            var result = _cache.GetOrExecute(query, () => _repository.GetUserItems(query));
            return result;
        }
    }
