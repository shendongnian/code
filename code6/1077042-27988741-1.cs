    [Authorize]
    [RoutePrefix("api/Account")]
    [UserAccessCheck] //check user id for all actions in controller
    public class AccountController : BaseApiController
    {
        //....
    }
    public class ValuesController : BaseApiController
    {
        //....
        [UserAccessCheck] //check user id for specific action only
        public IEnumerable<string> Get()
        {
            //...
        }
    }
