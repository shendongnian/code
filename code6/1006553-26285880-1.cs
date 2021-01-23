    public class HomeController : ApiController
    {
        [ActionName("GetById")]
        public string Get(int id)
        {
            return "id";
        }
        [ActionName("GetByGUID")]
        public string Get(string id)
        {
            return "guid";
        }
    }
