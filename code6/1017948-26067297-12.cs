    public class TestController : ApiController
    {
        //public TestController() { }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        //...
    }
