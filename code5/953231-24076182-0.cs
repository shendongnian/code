    public class FooController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ApplySomething(int? id=0)
        {
            ...
           return View();    
        }
        [HttpPost]
        public HttpResponseMessage ApplySomething(FormCollection Form,int? id=0)
        {
            ...
           return View();    
        }
    }
