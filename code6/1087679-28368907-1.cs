    [RoutePrefix("api/customers/{customer}/licences")]
    public class LicencesController : ApiController
    {
        // GET: api/Customers/1/licences
        [Route("")]
        public IEnumerable<Licence> Get(int customer)
        {
            return new List<Licence>
            {
                new Licence { Id = 1, Name = "Test" },
                new Licence { Id = 2, Name = "Test2" }
            };
        }
        // GET: api/Customers/1/licences/1
        [Route("{id}")]
        public Licence Get(int customer, int id)
        {
            return new Licence { Id = 1, Name = "Test" };
        }
    }
