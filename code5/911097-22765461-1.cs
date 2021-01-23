    public class MyController : Controller {
        public ActionResult Index(int? id) {
            if (id.HasValue)
            {
                ViewBag.MyInt = id;
            }
            return View();
        }
    }
