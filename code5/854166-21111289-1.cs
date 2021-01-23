	public class XRepository
	{
		private IDbSet<X> _dbSet;
		
		public IQueryable<X> Include()
		{
			return _dbSet;
		}
		
		public IQueryable<X> IncludeForA()
		{
			return Include().Include("B")
							.Include("C.D")
		}
	}
