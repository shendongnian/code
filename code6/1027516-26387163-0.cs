    [RoutePrefix("api/pagination")]
    public class MyController
    {
        [HttpGet]
        [Route("users")]
        public IEnumerable<Users> GetUsers() { }
    
        [HttpGet]
        [Route("users-paginated")]
        public IHttpActionResult UsersPagination(int startindex = 0, int size = 5, string sortby = "Username", string order = "DESC") { }
    }
