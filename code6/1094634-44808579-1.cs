    public class CustomApiController : ApiController
    {
        public IHttpActionResult EmptyResult()
        {
            return AsRRSearchWCFService.Filters.EmptyResult.GetInstance();
        }
    }
