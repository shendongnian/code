    public static class QueryableExtensions
    {
        public static IQueryable<T> PostProcess<T>(this IQueryable<T> source, Action<T> postProcessor) where T : class
        {
            return new QueryableWrapper<T>(source, postProcessor);
        }
        // wraps IQueryProvider.Execute methods with post-processing action
        class QueryProviderWrapper<T> : IQueryProvider where T : class
        {
            private readonly IQueryProvider _wrapped;
            private readonly Action<T> _postProcessor;
            public QueryProviderWrapper(IQueryProvider wrapped, Action<T> postProcessor)
            {
                _wrapped = wrapped;
                _postProcessor = postProcessor;
            }
            public IQueryable CreateQuery(Expression expression)
            {
                return _wrapped.CreateQuery(expression);
            }
            public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            {
                return _wrapped.CreateQuery<TElement>(expression);
            }
            public object Execute(Expression expression)
            {
                var result = _wrapped.Execute(expression);
                var asT = result as T;
                if (asT != null)
                    _postProcessor(asT);
                return result;
            }
            public TResult Execute<TResult>(Expression expression)
            {
                var result = _wrapped.Execute<TResult>(expression);
                var asT = result as T;
                if (asT != null)
                    _postProcessor(asT);
                return result;
            }
        }
        // wraps IQueryable.GetEnumerator() with post-processing action
        class QueryableWrapper<T> : IQueryable<T> where T : class
        {
            private readonly IQueryable<T> _wrapped;
            private readonly Action<T> _postProcessor;
            private readonly IQueryProvider _provider;
            public QueryableWrapper(IQueryable<T> wrapped, Action<T> postProcessor)
            {
                _wrapped = wrapped;
                _postProcessor = postProcessor;
                _provider = new QueryProviderWrapper<T>(_wrapped.Provider, postProcessor);
            }
            public Expression Expression
            {
                get { return _wrapped.Expression; }
            }
            public Type ElementType
            {
                get { return _wrapped.ElementType; }
            }
            public IQueryProvider Provider
            {
                get { return _provider; }
            }
            public IEnumerator<T> GetEnumerator()
            {
                return _wrapped
                    .AsEnumerable()
                    .Do(_postProcessor)
                    .GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
