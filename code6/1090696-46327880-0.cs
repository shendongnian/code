    public class SomeController : Controller
    {
        [HttpPost]
        public ActionResult SomeActionMethod()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestRedirection()
        {
            return RedirectToAction("SomeActionMethod", "Some");
        }
    }
