    public class ErrorController : Controller
    {
        public ActionResult Global()
        {
            return View("Global", ViewData.Model);
        }
        public ActionResult FileNotFound()
        {
            return View("FileNotFound", ViewData.Model);
        }
	}
