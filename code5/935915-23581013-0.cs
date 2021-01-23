    [RoutePrefix("api/My")]
    public class MyController : ApiController
    {
        [Route("MyController")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
        {....}
    }
