	public interface IRepository
	{
		void Add(object item);
		void Remove(object item);
		IQueryable<T> Query<T>() where T : class;
	}
