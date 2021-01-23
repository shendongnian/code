    public class HomeController : Controller
    {
      public ActionResult Index()
      {
        ViewData["Message"] = "Welcome to ASP.NET MVC!";
    
        Task.Run(()=> DoSomeAsyncStuff());
    
        return View();
      }
    
      private async void DoSomeAsyncStuff()
      {
    
      }
    }
