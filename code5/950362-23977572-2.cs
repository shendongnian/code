    [AllowAnonymous]
    public class HomeController
    {
      [Authorize]
      public ActionResult Index()
      {
        return View();
      }
    }
