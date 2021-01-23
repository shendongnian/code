    interface IQueryHandlerAdapter<TResponse>
    {
      TResponse Handle(IQuery<TResponse> query);
    }
    class QueryHandlerAdapter<TQuery, TResponse>
      where TQuery : class, IQuery<TResponse>
    {
      private readonly IQueryHandler<TQuery, TResponse> handler;
      public QueryHandlerAdapter(IQueryHandler<TQuery, TResponse> handler)
      {
        this.handler = handler;
      }
      public TResponse Handle(IQuery<TResponse> query)
      {
        var q = query as TQuery;
        if (q == null)
        {
          throw new InvalidOperationException("...");
        }
        return this.handler.Handle(q);
      }
    }
    class SynchronousQueryBus
    {
      private readonly IKernel kernel;
      public SynchronousQueryBus(IKernel kernel)
      {
        this.kernel = kernel;
      }
      public TResponse Resolve<TResponse>(IQuery<TResponse> query)
      {
        if (query == null)
        {
          throw new ArgumentNullException("query");
        }
        var handler = this.Kernel.Get<IQueryHandlerAdapter<TResponse>>();
        return handler.Handle(query);
      }
    }
