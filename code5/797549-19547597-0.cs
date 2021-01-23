   	public interface IUnitOfWork : IDisposable
	{
		IRepository<Cart> CartRepository { get; }
		IRepository<Product> ProductRepository { get; }
		void Save();
	}
	public class UnitOfWork : IUnitOfWork
	{
		readonly SqlDbContext _context;
		public UnitOfWork()
		{
			_context = new SqlDbContext();
		}
		private bool _disposed;
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		public void Save()
		{
			_context.SaveChanges();
		}
		public IGenericRepository<Cart> CartRepository
		{
			get { return new Repository<Cart>(_context); }
		}
		public IGenericRepository<User> UserRepository
		{
			get { return new Repository<User>(_context); }
		}
	}
