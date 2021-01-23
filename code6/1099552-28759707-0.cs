    public class HomeController : Controller
    {
            private readonly IMyBalService  _ibalService;
    
            public HomeController(IMyBalService ibalService)
            {
                _ibalService = ibalService;
            }
    
            public ActionResult Insert(Model M)
            {
               ibalService.Insert();
            }
     }
