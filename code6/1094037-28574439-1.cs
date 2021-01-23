    public class HomeController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
