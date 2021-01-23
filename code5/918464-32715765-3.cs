    public class MySagaRepository<TSaga> : ISagaRepository<TSaga> where TSaga : class, ISaga
    	{
		private ISagaRepository<TSaga> _inner;
		private readonly IComponentContext _context;
		public MySagaRepository(ISagaRepository<TSaga> inner, IComponentContext context)
		{
			_inner = inner;
			_context = context;
		}
		public IEnumerable<Action<IConsumeContext<TMessage>>> GetSaga<TMessage>(IConsumeContext<TMessage> context, Guid sagaId, InstanceHandlerSelector<TSaga, TMessage> selector, ISagaPolicy<TSaga, TMessage> policy) where TMessage : class
		{
			return _inner.GetSaga(context, sagaId, (saga, message) =>
			{
				_context.InjectProperties(saga);
				return selector(saga, message);
			}, policy);
		}
		public IEnumerable<Guid> Find(ISagaFilter<TSaga> filter)
		{
			return _inner.Find(filter);
		}
		public IEnumerable<TSaga> Where(ISagaFilter<TSaga> filter)
		{
			return _inner.Where(filter).Select(x =>
			{
				_context.InjectProperties<TSaga>(x);
				return x;
			});
		}
		public IEnumerable<TResult> Where<TResult>(ISagaFilter<TSaga> filter, Func<TSaga, TResult> transformer)
		{
			return _inner.Where(filter, x =>
			{
				_context.InjectProperties(x);
				return transformer(x);
			});
		}
		public IEnumerable<TResult> Select<TResult>(Func<TSaga, TResult> transformer)
		{
			return _inner.Select(x =>
			{
				_context.InjectProperties(x);
				return transformer(x);
			});
		}
	}
