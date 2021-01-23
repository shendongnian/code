    public class BaseController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new HasAssignedAcccessActionInvoker();
        }
    }
