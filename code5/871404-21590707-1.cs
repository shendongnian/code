    public class HomeController : Controller
    {
         private readonly UserRepository _userRepo;
         public HomeController()
         {
             _userRepo = new UserRepository();
         }
         public ActionResult Index()
         {
              var activeUsers = _userRepo.getActiveUsers();
              return View(activeUsers);
         }
    }
