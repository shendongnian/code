    RoutePrefix("api2/some")]
    public class SomeController : ApiController
    {
        // GET api2/books
        [Route("")]
        public IEnumerable<Some> Get() { ... }
    
        // GET api2/some/5 
        [Route("{id:int}")]
        public Some Get(int id) { ... } 
            
    }
