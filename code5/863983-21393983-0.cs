    public class FooController : ApiController
    {
        [System.Web.Http.Route("live/topperformers/{dateTime:datetime?}")]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public List<string> GetTopPerformers(DateTime? dateTime)
        {
            return new List<string>();
        }
    }
