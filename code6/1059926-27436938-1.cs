    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }
    
        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View("NotFound");
        }
    
        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View("InternalServer");
        }
    }
