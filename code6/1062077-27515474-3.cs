    [RoutePrefix("api/service")]
    public class ServicesController : ApiController
    {
        [HttpGet]
        [Route("{location}")]
        public IHttpActionResult GetByLocation(string location)
        {
            return Ok();
        }
        [HttpGet]
        [Route("{instanceId:int}")]
        public IHttpActionResult GetByInstanceId(int instanceId)
        {
            return Ok();
        }
    }
