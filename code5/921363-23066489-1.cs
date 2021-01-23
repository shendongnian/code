    [RoutePrefix("api/program")]
    public class ProgramController : ApiController
    {
        [Route("getbycriteria")]
        [HttpGet]
        public HttpResponseMessage GetByCriteria(
            [ModelBinder(typeof(CriteriaModelBinder))]CriteriaModel criteria
        )
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
