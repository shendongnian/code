    class QueryExceptionHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    {
        IQueryHandler<TQuery, TResult> _innerQueryHandler;
        public QueryLogHandler(IQueryHandler<TQuery, TResult> innerQueryHandler)
        {
            _innerQueryHandler = innerQueryHandler;
        }
        TResult Handle(TQuery query)
        {
             try
             {
                 var result = _innerQueryHandler.Handle(query);
             }
             catch(Exception ex)
             {
                  // Deal with exception here
             }
        }
    }
