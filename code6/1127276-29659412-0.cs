    [RoutePrefix("api/Sql")]
    public class SqlApiController : ApiController
    {
    
        [Route("OutageLastWeek/{serverName?}", Name = "SqlOutageLastWeek")]
        public HttpResponseMessage GetOutageLastWeek(string serverName = "")
        {
            // Some code...
        }
    }
