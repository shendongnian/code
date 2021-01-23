    public class TestController : ApiController {
        public HttpResponseMessage Get() {
              return something;
        }
        public HttpResponseMessage Get(int id) {
              return something with id;
        } 
    }
