    public class FirstController : BaseLoginController
    {
        [HttpPost]
        public ActionResult Login()
        {
            base.ExecuteLogin();
        }
    }
    
    public class SecondController : BaseLoginController
    {
        [HttpPost]
        public ActionResult ResetPassword()
        {
            base.ExecuteLogin();
        }
    }
    
    public class BaseLoginController
    {
        protected void ExecuteLogin()
        {
            // login logic
        }
    }
