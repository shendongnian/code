    class QueryDispatcher
    {
        public TReturnType Fetch<TReturnType>(IQuery<TReturnType> query) 
        {
            return myDIcontainer
                .Get<IQueryHandler<TReturnType, IQuery<TReturnType>>>()
                .Fetch(query);
        }
    }
