    public class HomeController : ApiController
    {
        [Route("home/id/{Id}")]
        [HttpGet]
        public string Get(int Id)
        {
            return "id";
        }
        [Route("home/string/{str}")]
        [HttpGet]
        public string Get(string str)
        {
            return "string";
       }
    }
