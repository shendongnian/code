    [Authorize]
    public class HomeController : Controller
    {
       public ActionResult Index()
       {
        return View()
        }
    
    [AllowAnonymous]
    public ActionResult Edit()
       {
        return View()
        }
    }
