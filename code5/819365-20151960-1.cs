    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            return this.NotFound("These are not the droids you're looking for.");
        }
    }
