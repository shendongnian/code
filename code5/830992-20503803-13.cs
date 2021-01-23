	public interface IRepository<T> where T : class
	{
		void Add(T item);
		void Remove(T item);
	}
	public abstract class RepositoryBase<T> : IRepository<T> where T : class
	{
		protected readonly IRepository Repository;
		protected RepositoryBase(IRepository repository)
		{
			Repository = repository;
		}
		public void Add(T item)
		{
			Repository.Add(item);
		}
		public void Remove(T item)
		{
			Repository.Remove(item);
		}
	}
	public interface ICustomerRepository : IRepository<Customer>
	{
		IList<Customer> All();
		IList<Customer> FindByCriteria(Func<Customer, bool> criteria);
	}
	public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
	{
		public CustomerRepository(IRepository repository)
			: base(repository)
		{ }
		public IList<Customer> All()
		{
			return Repository.Query<Customer>().ToList();
		}
		public IList<Customer> FindByCriteria(Func<Customer, bool> criteria)
		{
			return Repository.Query<Customer>().Where(criteria).ToList();
		}
	}
