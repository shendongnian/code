    public class AccountController : Controller
    {
        public AccountController()
            : this(new UserManager<User>(
                   new UserStore<User>(new MyEFDataModelContainer())))
        {
        }
    }
