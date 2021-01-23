    // Think of this as the "master decorator" - all calling code comes through here.
    class QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IComponentContext context;
        public QueryHandler(IComponentContext context)
        {
            this.context = context;
        }
        public TResult Handle(TQuery query)
        {
            var handler = context.Resolve<IQueryHandler<TQuery, TResult>>();
            if (typeof(TResult).IsClosedTypeOf(typeof(ReadOnlyCollection<>)))
            {
                // manual decoration:
                handler = new CachingQueryHandlerDecorator<TQuery, TResult>(handler);
                // or, container-assisted decoration:
                var decoratorFactory = context.Resolve<Func<IQueryHandler<TQuery, TResult>, CachingQueryHandlerDecorator<TQuery, TResult>>>();
                handler = decoratorFactory(handler);
            }
            if (NeedsAuthorization(query)) { ... }
            return handler.Handle(query);
        }
    }
