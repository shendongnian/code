    public class EventsController: Controller
    {
       public ActionResult Search(UserModel model)
       {
          //some operations goes here
    
          return View(); //return "Events" view to the user
          //return View(model); //You can also return view with the model to the user
       }
    }
