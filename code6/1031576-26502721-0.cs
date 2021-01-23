    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
    	public class LoginInfo
    	{
    		[Required]
    		public string Username { get; set; }
    
    		[Required]
    		public string Password { get; set; }
    	}
    
    	[Route("login")]
    	[HttpPost]
    	public IHttpActionResult AuthenticateUser(LoginInfo loginInfo)
    	{
    		if (!ModelState.IsValid)
    		{
    			return BadRequest(ModelState);
    		}
    
    		if (!Membership.ValidateUser(loginInfo.Username, loginInfo.Password))
    		{
    			ModelState.AddModelError("", "Incorrect username or password");
    			return BadRequest(ModelState);
    		}
    
    		FormsAuthentication.SetAuthCookie(loginInfo.Username, true);
    
    		return Ok();
    	}
    }
