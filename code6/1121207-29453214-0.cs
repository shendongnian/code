    public static class MyHelper
    {
        public static Foo DoSomething() { return new Foo();  }
    }
    public class MyController1 : Controller
    {
        public ActionResult Index()
        {
            var result = MyHelper.DoSomething();
            return FileResult(...);
        }
    }
    public class MyController2 : Controller
    {
        public ActionResult Index()
        {
            var result = MyHelper.DoSomething();
            return JSONResult(...);
        }
    }
