    public class ErrorController : Controller
        {
            // GET: Error
            [HttpGet]
            public ViewResult Index(Int32? id)
            {
                var statusCode = id.HasValue ? id.Value : 500;
                var error = new HandleErrorInfo(new Exception("An exception with error " + statusCode + " occurred!"), "Error", "Index");
    
                int errorCode = statusCode;
                ViewBag.error = errorCode;
                return View("Error");
            }
        }
