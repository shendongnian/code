    public class CustomersController : ApiController
    {
        private readonly CutomerContext _context = new CustomerContext();
        private DbContextTransaction _transactionContext;
        public IEnumerable<Customer> Get()
        {
            _transactionContext = _context.Database.BeginTransaction();
            _context.Database.ExecuteSqlCommand("SET ANSI_WARNINGS OFF");
            _context.Database.ExecuteSqlCommand("SET ARITHABORT OFF");
            var orderedCustomers = _context.Customers.OrderByDescending(c => ((double)c.MoneySpent)/c.OrdersPlaced);
            return orderedCustomers.AsEnumerable();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            if(_transactionContext != null)
                _transactionContext.Dispose();
        }
    }
