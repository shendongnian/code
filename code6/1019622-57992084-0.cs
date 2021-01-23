     public interface IQueryCache
     {
         TResult GetOrExecute<TQuery, TResult>(TQuery query, Func<TResult> func)
             where TQuery : IQuery<TResult>
             where TResult : class;
     }
