    public class TestController : Controller
    {
        private readonly IMyClass _myClass;
        public TestController(IMyClass myClass)
        {
            _myClass = myClass;
        }
        // Rest of the controller
    }
