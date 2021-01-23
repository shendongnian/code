    public class ValuesController : ApiController
    {
        [Route("~/api/values")]
        [HttpGet]
        public IHttpActionResult First(string email)
        {
            return this.Ok("first");
        }
    }
    [RoutePrefix("api/values")]
    public class ValuesTwoController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Second(string email)
        {
            return this.Ok("second");
        }
    }
