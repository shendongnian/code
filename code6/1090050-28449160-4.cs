    public class HomeController : Controller
    {
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Countries(int id, int from = 0)
        {
            return Json(from);
        }
    }
