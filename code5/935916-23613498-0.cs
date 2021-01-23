    [RoutePrefix("api")]  // or maybe "api/", can't recall OTTOMH...
    public class MyController : ApiController
    {
        [Route("MyController")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string value)
