    public class UsersController : ApiController
    {
        private IUsersService service;
        public FooController(IUsersService service)
        {
            this.service = service;
        }
        ...
    }
