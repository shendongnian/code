    // Route /status to this controller
    [RoutePrefix("status")]
    public class StatusController : ApiController
    {
        [HttpGet] // accept get
        [HttpPost] // accept post
        [Route("")] // route default request to this method.
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
