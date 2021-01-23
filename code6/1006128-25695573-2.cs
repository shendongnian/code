    class GetCustomersHandler : IQueryHandler<CustomerQuery, List<Customer>>
    {
        List<Customer> Handle(CustomerQuery query)
        {
            // CustomerQuery is a simple message type class which contains country and orderby
            // just as in the original method, but now packed up in a 'message'
        }
    }
    class CreateInvoiceHandler : ICommandHandler<CreateInvoice>
    {
        public void Handle(CreateInvoice command)
        {
            // CreateInvoice is a simple message type class which contains customerId and amount
            // just as in the original method, but now packed up in a 'message'
        }
    }
