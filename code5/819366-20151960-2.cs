    public class CustomApiController : ApiController
    {
        protected NotFoundTextPlainActionResult NotFound(string message)
        {
            return new NotFoundTextPlainActionResult(message, Request);
        }
    }
    public class TestController : CustomApiController
    {
        public IHttpActionResult Get()
        {
            return NotFound("These are not the droids you're looking for.");
        }
    }
