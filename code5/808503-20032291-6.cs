	/// <summary>
	/// All derived handlers can be refactored using generics. But in the real world handling logic can be completely different.
	/// </summary>
	/// <typeparam name="TQuery">The type of the query.</typeparam>
	/// <typeparam name="TResponse">The type of the response.</typeparam>
	public interface IQueryHandler<in TQuery, out TResponse> : IQueryHandler
		where TQuery : IQuery<TResponse>
	{
		TResponse Handle(TQuery query);
	}
	/// <summary>
	/// This interface is used in order to invoke 'Handle' for any query type.
	/// </summary>
	public interface IQueryHandler
	{
		object Handle(object query);
	}
	/// <summary>
	/// Implements 'Handle' of 'IQueryHandler' interface explicitly to restrict its invocation.
	/// </summary>
	/// <typeparam name="TQuery">The type of the query.</typeparam>
	/// <typeparam name="TResponse">The type of the response.</typeparam>
	public abstract class QueryHandlerBase<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
		where TQuery : IQuery<TResponse>
	{
		public abstract TResponse Handle(TQuery query);
		object IQueryHandler.Handle(object query)
		{
			return Handle((TQuery)query);
		}
	}
