    public interface Query<TResult> { }
    public interface QueryProcessor
    {
            TResult Process<TResult>(Query<TResult> query);
    }
    public interface QueryHandler<in TQuery, out TResult> where TQuery : Query<TResult>
    {
            TResult Handle(TQuery query);
    }
    //GetSomethingByIdQuery Implements : Query<Something>
    //so Something will be the return value 
    queryProcessor.Process(new GetSomethingByIdQuery());    
    //Query Processor
    public TResult Process<TResult>(Query<TResult> query)
    {
           var handlerType = typeof(QueryHandler<,>)
           .MakeGenericType(query.GetType(), typeof(TResult));
    
       dynamic handler = _container.Resolve(handlerType);
    
        
       return handler.Handle((dynamic)query);
    }
