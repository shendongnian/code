    public class CustomerProcessor : ICustomerProcessor {
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;
        public CustomerProcessor(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }
        public IEnumerable<Customer> GetAll()
        {
            var data = _customerRepository.GetDataTable();
            return _customerFactory.CreateCustomers(data);
        }
    }  
