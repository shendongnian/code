    [Authorize]
    public class CustomerServiceController
    {
         ....
    }
            
    public class AccountController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ....
        }
        [Authorize]
        public ActionResult Accounts()
        {
            ....
        }
    }
