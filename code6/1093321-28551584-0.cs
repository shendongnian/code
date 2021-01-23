    public class OffsetController : ApiController
    {
        [Route("offset", Name = "Offset")]
        public IHttpActionResult Get(System.DateTimeOffset date)
        {
            return this.Ok("Received: " + date);
        }
        [Route("offset", Name = "Default")]
        public IHttpActionResult Get()
        {
            var routeValues = new { date = System.DateTimeOffset.Now };
            return this.RedirectToRoute("Offset", routeValues);
        }
    }
