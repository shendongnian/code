    public class TestController : ApiController
    {
        public string GetHello(string name)
        {
             return String.Format("Hello, {0}!", name);
        }
    }
