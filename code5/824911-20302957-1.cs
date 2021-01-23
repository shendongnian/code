     public class BaseController : Controller
     {  
        public BaseController()
        {
            //I don't know how you get your data
            ViewBag.DatabaseMenu =  repository.GetMenuItems();
        }
     }
