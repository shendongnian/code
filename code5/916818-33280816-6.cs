    public class EventsController: Controller
    {
       // just to show page /Events/Index
       public ActionResult Index()
       {
           return View();
       }
       public ActionResult Search(UserModel model)
       {
          //do something with model.Name
          return View(); //return "Search" view to the user
          //return View(model); //You can also return view with the model to the user
          //return View("SpecificView"); //You can specify a concrete view name as well 
       }
    }
