    public class MyController : ApiController
    {
        [Authorize]
        [Route("MyController")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
        {....}
    }
