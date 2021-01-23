    public class PostController : Controller
    {
    	[HttpGet]
    	public ActionResult Index(string text)
    	{
    		if (string.IsNullOrWhiteSpace(text))
    			return Content("Please specifiy a value for text.  i.e. /Post/Index?text=Message");
    
    		var message = "";
    
    		var isAuthenticated = Request.Cookies["ident"] != null;
    		if (isAuthenticated)
    		{
    			var userId = Request.Cookies["ident"].Value;
    			var post = new
    			{
    				Text = text,
    				User = userId
    			};
    			// Save to database here
    			message = "You are a previously recognized user, with UserId=" + userId;
    		}
    		else
    		{
    			var userId = Guid.NewGuid().ToString();
    			var identCookie = new HttpCookie("ident", userId);
    			Response.Cookies.Add(identCookie);
    
    			var post = new
    			{
    				Text = text,
    				User = userId
    			};
    			// Save to database
    			message = "You are a new anonymous user. Your new UserId=" + userId;
    		}
    
    		return Content(message);
    	}
    }
