    public class HomeController : Controller
    {
       [AllowAnonymous]
       public ActionResult AllowAllUserAction()
       {
          
       } 
       [Authenticate]
       public ActionResult SomeAction()
       {
          
       }
    }
