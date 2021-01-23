    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            string request = this.Request.QueryString["ReturnUrl"];
        }
    }
