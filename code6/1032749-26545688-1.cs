    public class TestController : ApiController
    {
        public void Post(Data value)
        {
          int id = value.id;
          string name = value.name;
        }
    }
