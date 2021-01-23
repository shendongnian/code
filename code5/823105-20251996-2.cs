    class CustomerForm
    {
        private readonly ICustomerRepository customerRepository;
        // This class declares a dependency on any ICustomerRepository
        public CustomerForm(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void PersistCustomer()
        {
            Customer customer = CreateCustomerFromUserInput();
            
            this.customerRepository.Save(customer);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency injection, usually done via a DI container
            var customerRepository = new SqlCustomerRepository();
            var form = new CustomerForm(customerRepository);
            form.PersistCustomer();
        }
    }
