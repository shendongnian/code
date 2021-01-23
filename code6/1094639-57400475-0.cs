    public class MyController : ApiController
    {
        public IHttpActionResult Get()
        {
            HttpStatusCode codeNotDefined = (HttpStatusCode)429;
            return Content(codeNotDefined, "message to be sent in response body");
        }
    }
