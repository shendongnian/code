     public class LoginController : Controller
     {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel() { Authenticated = true } );
        }
     }
