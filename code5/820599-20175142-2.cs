    public class CustomersController : ApiController
    {
        // This will match GET /api/customers
        public HttpResponseMessage Get()
        {
            Customer[] res = CustomerRepository.GetAllCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        // This will match GET /api/customers?term=foo_bar
        public HttpResponseMessage Get(string term)
        {
            Customer[] res = CustomerRepository.GetAllOrForTerm(term);
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
        // This should match POST /api/customers
        public HttpResponseMessage Post(Customer customer)
        {
            ...
            return Request.CreateResponse(HttpStatusCode.Created, customer);
        }
    }
