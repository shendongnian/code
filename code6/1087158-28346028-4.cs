    public class ChatController : Controller
    {
       private IMyDataService _service;
       public ChatController(IMyDataService s)
       {
          _service = s;
       }
    
       public ActionResult Index()
       {
          return View(new MyDataViewModel(_service));
       }
    
    }
