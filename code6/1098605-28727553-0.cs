    [Authorize]
    public class AccountController : Controller
    {
        ...
        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult UserInfo()
        {
            // get your user info here
            return PartialView("UserInfo", userInfo);
        }
    }
