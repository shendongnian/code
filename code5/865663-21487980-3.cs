    public class ValuesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return new CustomOkResult<string>(content: "Hello World!", controller: this)
                {
                        ETagValue = "You ETag value"
                };
        }
    }
