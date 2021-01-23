    public class CustomApiController : ApiController
    {
        public IHttpActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
