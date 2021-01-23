    public class CustomerValidator
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Orders).SetCollectionValidator(new OrderValidator());
        }
    }
    public class OrderValidator
    {
        public OrderValidator()
        {
             RuleFor(order => order.TotalValue)
                 .Must((order, total) => total <= order.Customer.MaxOrderValue)
                 .WithState(order => GetErrorInfo(order)); // pass order info into state
        }
    }
