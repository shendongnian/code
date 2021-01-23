    public class ValuesController : BaseController
    {
        [Route("/get/value")]
        public string GetValue()
        {
            return "hello";
        }
    }
