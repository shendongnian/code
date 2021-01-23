    namespace ABMCEditAndReports.Controllers
    {
        public class LoginController : Controller
        {
            //
            // GET: /Login/
    
            public ActionResult Index(string returnUrl = null)
            {
                this.ViewBag.ReturnUrl = returnUrl;
                return View("LoginPage");
            }
            public ActionResult Index(LogInViewModel model, string returnUrl)
            {
                if (this.ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return this.Redirect(returnUrl);
                }
                this.ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return this.View(model);
            }
        }
    }
