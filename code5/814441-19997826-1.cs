    public class AccountsController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginPage loginPage)
        {
            if (ModelState.IsValid)
            {
                using (var userDao = new UserDao())
                {
                    var user = userDao.GetUser(loginPage.Login);
                    if (user != null && user.Password == loginPage.Password)
                    {
                        FormsAuthentication.SetAuthCookie(loginPage.Login, loginPage.RememberMe);
                        return RedirectToAction("Index", "Campaigns");
                    }
                }
            }
            return View(loginPage);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
