    public class HomeController : Controller
    {
        private readonly IFoo _foo;
        public HomeController(IFoo foo) // inject dependency
        {
            _foo = foo;
        }
        public ActionResult GetZZ()
        {
            ApplyResponseHeaders();
            var result = new JsonResult();            
            MyFunction(_foo.Bar(), result); // use dependency
            return result;
        }
    }
