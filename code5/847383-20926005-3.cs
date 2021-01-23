    public class ErrorController : Controller
    {
        public ActionResult Details(int statusCode)
        {
            return View(new { StatusCode = statusCode });
        }
    }
