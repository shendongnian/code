    [RouteArea("ar")]
    [RoutePrefix("ctl")]
    public class MyControllerNameDoesNotMatter : Controller {
        ...        
        [Route("a/{optionalParamDefaultsToNegativeOne=-1}")]
        public ActionResult Index(int optionalParamDefaultsToNegativeOne) {
            ...
        }
    }
