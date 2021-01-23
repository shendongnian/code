    public interface IQueryHandler<out TResponse>
    {
        TResponse Handle(object query);
    }
    public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TResponse>
    {
        TResponse IQueryHandler<TResponse>.Handle(object query)
        {
            return Handle((TQuery)query);
        }
        protected abstract TResponse Handle(TQuery query);
    }
    public TResponse Resolve<TResponse>(IQuery<TResponse> query)
    {
        var handlerType = typeof(IQueryHandler<TResponse>);
        IQueryHandler<TResponse> handler = kernel.Get(handlerType);
        return handler.Handle(query);
    }
