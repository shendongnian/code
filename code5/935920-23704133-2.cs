    [RoutePrefix("api")]
    public class MyController : ApiController
    {
        [Route("MyController")]
        public HttpResponseMessage Post([FromBody]string value)
