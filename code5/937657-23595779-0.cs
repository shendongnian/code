    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if ((this.User.IsInRole("Admin")))
            {
                return RedirectToAction("Action");
            }
            this.HttpContext.Session["foo"] = "bar";
            return View();
        }
    }
