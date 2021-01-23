    public class ErrorPageController : Controller
    {
	    public ActionResult Error(int statusCode, Exception exception)
	    {
		    Response.StatusCode = statusCode;
		    ViewBag.StatusCode = statusCode + " Error";
		    return View();
	    }
    }
		
		
		
