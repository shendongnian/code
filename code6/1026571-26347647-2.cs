    [RequireHttps]
    public class MyController : ApiController {
        // only https requests will get through to this method.
        [HttpGet]
        public IHttpActionResult Get() {
           return Ok();
        }
    }
