    public class Customer
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public interface IUnitOfWork
    {
        int Save();
    }
    public interface IBaseRepository<TEntity, TKey> : IUnitOfWork where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Find(TKey id);
        IEnumerable<TEntity> GetAll();
    }
    
    public interface ICustomerRepository :IBaseRepository<Customer, int>
    {
    }
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer entity)
        {
            throw new System.NotImplementedException();
        }
        public Customer Find(int id)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }
        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
    public class UnitOfWork : IUnitOfWork
    {
        private ICustomerRepository _customers;
        public ICustomerRepository Customers
        {
            get { return _customers; }
        }
        public UnitOfWork()
        {
            _customers = new CustomerRepository();
        }
        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
