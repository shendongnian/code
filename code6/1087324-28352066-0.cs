    public class CommonController : Controller
    {
        // Error
        public ActionResult Error()
        {
            this.Response.StatusCode = 503;
            this.Response.TrySkipIisCustomErrors = true;
    
            return View();
        }
    }
