     public class SecuredController : Controller
       {
            [Authorize]
            public ActionResult Secure()
            {
                return View();
            }
    
            public ActionResult NonSecure()
            {
                return View();
            }
       }
