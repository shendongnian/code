    public class MyController : ApiController
        {
            private readonly IMyClass _myClass;
    
            public MyController(IMyClass myClass)
            {
                _myClass = myClass;
            }
        }
