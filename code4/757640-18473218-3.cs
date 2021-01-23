    public class UsersController : ApiController
    {
        private IUsersService service;
        public UsersController(IUsersService service)
        {
            this.service = service;
        }
        ...
    }
