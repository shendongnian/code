    public class HomeController : Controller
    {
       public ActionResult Index()
       {
          int count;
          using (var db = new LocalContext())
          {
             count = db.Counters.Count();
          }
    
          GC.Collect();
          return View(count);
       }
    }
