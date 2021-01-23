    [Authorize]
    public class AccountController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // do stuff
                TempData["UserType"] = userType;
                return RedirectToAction("Index", "Home");
            }
            // something went wrong, return view
            return View(model);
        }
    }
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserType = TempData["UserType"];
            return View();
        }
    }
