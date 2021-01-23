    public class CustomerViewModel
    {
        private ICommandHandler<AddCustomer> addCustomerCommandHandler;
        public CustomerViewModel(ICommandHandler<AddCustomer> addCustomerCommandHandler) {
            this.addCustomerCommandHandler = addCustomerCommandHandler;
        }
        public void AddCustomer(Customer customer)
        {
            this.addCustomerCommandHandler.Handle(new AddCustomer(customer));
        }
    }
