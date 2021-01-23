    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [Route("~/api/customers.{ext}")]
        [Route]
        public string Get()
        {
            return "Get All Customers";
        }
    
        [Route("{id}.{ext}")]
        [Route("{id}")]
        public string Get(int id)
        {
            return "Get Single Customer";
        }
    
        [Route]
        public string Post(Customer customer)
        {
            return "Created Customer";
        }
    
        [Route("{id}")]
        public string Put(int id, Customer customer)
        {
            return "Updated Customer";
        }
    
        [Route("{id}")]
        public string Delete(int id)
        {
            return "Deleted Customer";
        }
    }
