    public abstract class BaseController : Controller
    {
    
        public bool IsReadOnly { get; set; }
    
        public BaseController()
        {
            this.IsReadOnly = Roles.IsUserInRole("readonly");
        }
    }
    
    public class HomeController : BaseController
    {
    	[Authorize(Roles = "admin, user, readonly")]
        public ActionResult Edit(int id)
        {
    		if (!IsReadOnly)
    		{
    			return View("Details");
    		}
    		... other stuff
    	}
    }
