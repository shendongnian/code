    public class CustomerValidator: AbstractValidator<Customer> 
    {
        RuleFor(customer => customer.Property1).NotNull();
        RuleFor(customer => customer.Property2).NotNull();
        RuleFor(customer => customer.Property3).NotNull();
    }
    public class Customer
    {
        public Customer(string property1, string property2, string property3)
        {
             Property1  = property1;
             Property2  = property2;
             Property3  = property3;
             new CustomerValidator().ValidateAndThrow();
        }
        public string Property1 {get; set;}
        public string Property2 {get; set;}
        public string Property3 {get; set;}
    }
