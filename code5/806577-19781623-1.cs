    [RoutePrefix("MyApp")]
    public class MyController : Controller {
        
        [Route("~/")] //1
        [Route("Index")] //2
        public ActionResult Index() {
            ...
        }
    }
