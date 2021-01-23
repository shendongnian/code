    using System.Web.Http;
    
    public class UserController : ApiController
    {
        [Route("user/getalluser")]
        public IEnumerable<User> Get()
        {
            return GetAllUser();
        }
    }
