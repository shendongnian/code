    public class MyController: ApiController
    {
        // Matches my/hello
        [Route("my/{somevalue}")]
        [HttpGet]
        public string MethodOne(string somevalue)
        {
            return somevalue;
        }
        // Matches my/hello/1234
        [Route("home/{somevalue}/{id}")]
        [HttpGet]
        public int MethodTwo(int id)
        {
            return id;
       }
    }
