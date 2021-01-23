    [RoutePrefix("Round")]
    public class RoundController : ControllerBase
    {
        [Route("{groupid}/{campaignid}/{accesstoken}")]
        public async Task<ActionResult> TempRoundLink(string groupid, string campaignid, string accesstoken)
        {
        }
    }
    
    [RoutePrefix("Account")]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [Route("Account/ResetPassword/{token}")]
        public async Task<ActionResult> ResetPassword(string token)
        {
        }
    }
