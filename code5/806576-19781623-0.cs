    [RoutePrefix("MyApp")]
    public class MyController : Controller {
        
        [GET("", IsAbsoluteUrl = true)] //1
        [GET("Index")] //2
        public ActionResult Index() {
            ...
        }
    }
