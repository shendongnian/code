    public class Repository<TModel> where TModel: class
    {
		public Repository<TModel>(Context context)
		{
			_context = context;
		}
		private Context _context;
		...
		public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> where)
		{
			return _context.CreateObjectSet<TModel>().Where(where);
		}
		public IEnumerable<TResult> GetColumn(Func<TSource, TResult> selector)
		{
			return _context.CreateObjectSet<TModel>().Select(selector);
		}
    }
