    [Authorize]
    public class PostController : Controller
    {
    	[AllowAnonymous]
    	public HttpStatusCodeResult CreatePost(string postText)
    	{
    		// Use ASP.NET Identity to see if the user is logged in.  
    		// If they are, we can get their User Id (blank otherwise)
    		var isAuthenticated = User.Identity.IsAuthenticated;
    		var userId = "";
    		if (isAuthenticated)
    			userId = User.Identity.GetUserId();
    
    		// Create a new post object
    		var post = new
    		{
    			PostText = postText,
    			Anonymous = !isAuthenticated,
    			UserId = userId
    		};
    
    		// Save the post to the database here
    
    		return new HttpStatusCodeResult(HttpStatusCode.OK);
    	}
    }
