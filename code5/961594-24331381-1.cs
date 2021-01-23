    [ExclusiveAction] //either here, for every action in the controller
    public class MyController : Controller
    {
        [ExclusiveAction] //or here for specific methods
        public ActionResult DoTheThing()
        {
            //foo
            return SomeActionResult();
        }
    }
