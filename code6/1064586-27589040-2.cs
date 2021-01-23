      public class UserController : Controller
      {
         private readonly IUserService _service;
         //Consider using a Dependency injection framework e.g. Unity
         public UserController(IUserService service)
         { 
            this.service = service;
         } 
         //The method that is tightly coupled to the view and uses the service
         [HttpGet] 
         public ActionResult GetUserByID(int id)
         {
              return View(_service.GetUserById(id));
         }
     }
