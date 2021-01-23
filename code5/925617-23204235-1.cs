    [Authorize]
    public class PostController : Controller
    {
    	[AllowAnonymous]
    	public ActionResult Index()
    	{
    		var isAuthenticated = User.Identity.IsAuthenticated;
    
    		return View();
    	}
    }
