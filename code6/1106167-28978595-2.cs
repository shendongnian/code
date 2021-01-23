    public class CustomerService
    {
        private IDomainEventDispatch _dispatcher;
        private ICustomerRepository _customerRepository;
    
        public CustomerService(ICustomerRepository customerRepository, IDomainEventDispatch dispatcher)
        {
            _customerRepository = customerRepository;
            _dispatcher = dispatcher;
        }
    
        public void Enable(Guid customerId)
        {
            _dispatcher.Raise(_customerRepository.Get(customerId).Enable());
        }
    }
