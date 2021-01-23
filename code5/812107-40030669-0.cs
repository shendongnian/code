    public class MixedCodeStandardController : ApiController {
        public readonly object _data = new Object();
        public IHttpActionResult Get() {
            return Ok(_data);
        }
        public IHttpActionResult Get(int id) {
            return Content(HttpStatusCode.Success, _data);
        }
    }
