    interface IQuery<TQuery, TQueryResult> : IQuery {}
    interface IQueryResult<T> : IQueryResult 
    { 
        T Result { get; }
    }
