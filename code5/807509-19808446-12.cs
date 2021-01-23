    public interface ICachePolicy<TQuery>
    {
        DateTime AbsoluteExpiration { get; }
    }
    public class CachePolicy<TQuery> : ICachePolicy<TQuery>
    {
        public CachePolicy()
        {
            AbsoluteExpiration = Cache.NoAbsoluteExpiration;
        }
        public DateTime AbsoluteExpiration { get; set; }
    }
    public interface IQueryHandler<TQuery, TResult> { }
    public class QueryHandlerA : IQueryHandler<A, AResult> { }
    public class QueryHandlerB : IQueryHandler<B, BResult> { }
    public sealed class CachingQueryHandlerDecorator<TQuery, TResult>
        : IQueryHandler<TQuery, TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> decorated;
        public readonly ICachePolicy<TQuery> Policy;
        public CachingQueryHandlerDecorator(
            IQueryHandler<TQuery, TResult> decorated,
            ICachePolicy<TQuery> cachePolicy)
        {
            this.decorated = decorated;
            this.Policy = cachePolicy;
        }
    }
