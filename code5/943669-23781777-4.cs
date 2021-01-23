    public class CustomerRepositoryProxy : ICustomerRepository
    {
        private readonly Func<ICustomerRepository> repositoryFactory;
        public CustomerRepositoryProxy(Func<ICustomerRepository> repositoryFactory) {
            this.repositoryFactory = repositoryFactory;
        }
        public void Add(Customer customer) {
            var repository = this.repositoryFactory.Invoke();
            repository.Add(customer);
        }
    }
