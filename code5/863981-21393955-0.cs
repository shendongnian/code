    public class FooController : ApiController
        {
            [System.Web.Http.Route("live/topperformers/{dateTime:DateTime?}")]
            [System.Web.Http.AcceptVerbs("GET", "POST")]
            [System.Web.Http.HttpGet]
            public List<string> GetTopPerformers(DateTime? dateTime = null)
            {
                return new List<string>();
            }
    }
