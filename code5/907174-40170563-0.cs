    [RoutePrefix("api/v1/profile")]
    public class ProfileController : ApiController
    {
       ...
       [HttpGet]
       [Route("{profileUid}")]
       public IHttpActionResult GetProfile(string profileUid, long? someOtherId) 
       {
          // ...
       }
       ...
    }
