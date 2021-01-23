    public class AccountController : Controller
    {
        public AccountController ()
        {
            Context = new ApplicationDbContext()
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
        }
        protected ApplicationDbContext Context { get; private set; }
        protected UserManager<User> UserManager { get; private set; }
    }
