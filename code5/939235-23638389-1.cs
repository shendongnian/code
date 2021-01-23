    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        public class LoginInfo
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    
        [Route("login")]
        [HttpPost]
        public IHttpActionResult AuthenticateUser(LoginInfo loginInfo)
        {
            if (string.IsNullOrEmpty(loginInfo.username) || string.IsNullOrEmpty(loginInfo.password))
            {
                return BadRequest("You must submit username and password");
            }
    
            if (!Membership.ValidateUser(loginInfo.username, loginInfo.password))
            {
                return BadRequest("Incorrect username or password");
            }
    
            FormsAuthentication.SetAuthCookie(loginInfo.username, true);
    
            return Ok();
        }
    }
