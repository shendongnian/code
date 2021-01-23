    [RoutePrefix("api/program")]
    public class ProgramController : ApiController
    {
        [Route("getbycriteria")]
        [HttpPost]
        public HttpResponseMessage GetByCriteria(CriteriaModel criteria)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
