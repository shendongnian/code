    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { 
                "This is a CORS request.", 
                "That works from any origin." 
            };
        }
        // GET api/values/another
        [HttpGet]
        [EnableCors(origins:"http://www.bigfont.ca", headers:"*", methods: "*")]
        public IEnumerable<string> Another()
        {
            return new string[] { 
                "This is a CORS request.", 
                "It works only from www.bigfont.ca." 
            };
        }
    }
