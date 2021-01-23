    [RoutePrefix("api/Oracle")]
    public class OracleApiController : ApiController
    {
    
        [Route("OutageLastWeek/{serverName?}", Name = "OracleOutageLastWeek")]
        public HttpResponseMessage GetOutageLastWeek(string serverName = "")
        {
            // Some code...
        }
    }
