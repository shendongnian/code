    public class CustomersController : ApiController
    {
        // GET: api/Customers
        public IEnumerable<Customer> Get()
        {
            return new List<Customer> 
            {
                new Customer { Id = 1, Name = "Wayne" },
                new Customer { Id = 2, Name = "John" }
            };
        }
        // GET: api/Customers/5
        public Customer Get(int id)
        {
            return new Customer { Id = 1, Name = "Wayne" };
        }
    }
