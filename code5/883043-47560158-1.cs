    public class UsersController : BaseController
    {
        // and any other services I need are here:
        private readonly IAnotherService svc;
        public UsersController(IAnotherService svc)
        {
            this.svc = svc;
        }
    ...
    }
