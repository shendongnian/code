        public class MyObject 
        {
          public string Content { get; set; }
        }
    Controller for it:
    
        public class TestController : ApiController
        {
          [HttpGet]
          public MyObject Example() {
            return new MyObject() { Content = "Hello World!" };
          }
        }
