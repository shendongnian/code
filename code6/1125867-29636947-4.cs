    [Permission(Permissions.ManageCustomerDetails)]
    public class UpdateCustomerDetailsCommand {
        public Guid CustomerId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [ValidBirthDate] public DateTime DateOfBirth { get; set; }
    }
    public class UpdateCustomerDetailsCommandHandler
        : ICommandHandler<UpdateCustomerDetailsCommand> {
        public UpdateCustomerDetailsCommandHandler(
            IRepository<Customer> _customerRepository, 
            IRepository<Order> orderRepository, 
            IManager itemManager) {
            _orderReporsitory = orderReporsitory;
            _itemManager = itemManager;
            _customerRepository = customerRepository;
        }
        public void Handle(UpdateCustomerDetailsCommand command) {
            var customer = _customerRepository.GetById(command.CustomerId);
            customer.FirstName = command.FirstName;
            customer.LastName = command.LastName;
            customer.DateOfBirth = command.DateOfBirth;
        }
    }
    
