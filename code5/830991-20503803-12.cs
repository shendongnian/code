	public class EntityFrameworkRepository : IRepository
	{
		public readonly EntityFrameworkUnitOfWork unitOfWork;
		public EntityFrameworkRepository(IUnitOfWork unitOfWork)
		{
			var entityFrameworkUnitOfWork = unitOfWork as EntityFrameworkUnitOfWork;
			if (entityFrameworkUnitOfWork == null)
			{
				throw new ArgumentOutOfRangeException("Must be of type EntityFrameworkUnitOfWork");
			}
			this.unitOfWork = entityFrameworkUnitOfWork;
		}
		public void Add(object item)
		{
			unitOfWork.GetDbSet(item.GetType()).Add(item);
		}
		public void Remove(object item)
		{
			unitOfWork.GetDbSet(item.GetType()).Remove(item);
		}
		public IQueryable<T> Query<T>() where T : class
		{
			return unitOfWork.GetDbSet<T>();
		}
	}
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
	}
	public class EntityFrameworkUnitOfWork : IUnitOfWork
	{
		private readonly DbContext context;
		public EntityFrameworkUnitOfWork()
		{
			this.context = new CustomerContext();
		}
		internal DbSet<T> GetDbSet<T>()
			where T : class
		{
			return context.Set<T>();
		}
		internal DbSet GetDbSet(Type type)
		{
			return context.Set(type);
		}
		public void Commit()
		{
			context.SaveChanges();
		}
		public void Dispose()
		{
			context.Dispose();
		}
	}
