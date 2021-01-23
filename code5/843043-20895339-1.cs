    public class AccountController : Controller
    {
        public AccountController()
            : this(new MyUserManager())
        {
        }
        public AccountController(MyUserManager userManager)
        {
            UserManager = userManager;
        }
        public MyUserManager UserManager { get; private set; }
    [etc.]
