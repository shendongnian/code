    public class ProductController : Controller
    {
        [HttpPost]
        public ActionResult Create(DateTime date)
        {
            ViewBag.Date = date;
            return View();
        }
    }
