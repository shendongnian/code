    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { 
                "This is a CORS response.", 
                "It works from any origin." 
            };
        }
        // GET api/values/another
        [HttpGet]
        [EnableCors(origins:"http://www.bigfont.ca", headers:"*", methods: "*")]
        public IEnumerable<string> Another()
        {
            return new string[] { 
                "This is a CORS response. ", 
                "It works only from two origins: ",
                "1. www.bigfont.ca ",
                "2. the same origin." 
            };
        }
    }
