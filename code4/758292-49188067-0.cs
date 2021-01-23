    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ModelState.ToList().Select(x => x.Value).ToList().ForEach(x => { x.AttemptedValue = null; x.RawValue = null; });
            // Do a bunch of stuff here if needed. Stuff like validation.
            base.OnActionExecuted(context);
        }
    }
