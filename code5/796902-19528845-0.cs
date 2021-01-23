    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        // GET api/users
        [Route("")]
        public IEnumerable<User> Get() { ... }
    
        // GET api/user/5
        [Route("{id:int}")]
        public Book Get(int id) { ... }
    
        // POST api/users
        [Route("")]
        public HttpResponseMessage Post(User book) { ... }
    }
