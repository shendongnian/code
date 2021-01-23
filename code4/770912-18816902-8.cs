    public class CustomersService : Service
    {
        private readonly CustomerContext _dbCustomerContext;
        public CustomersService(CustomerContext dbCustomerContext)
        {
            _dbCustomerContext = dbCustomerContext;
        }
        public object Get(GetCustomer request)
        {
            return _dbCustomerContext.Customers
                   .FirstOrDefault(c => c.Id == request.Id)
                   .Select(c => c.Translate());
        }
        public object Get(GetCustomers request)
        {
            if (string.IsNullOrEmpty(request.LastName))
            {
                return _dbCustomerContext.Customers.ToList()
                       .Select(c => c.Translate());
            }
            return _dbCustomerContext.Customers
                   .Where(c => c.LastName == request.LastName).ToList()
                   .Select(c => c.Translate());
        }
    }
