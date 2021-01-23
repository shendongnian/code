    class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            if (somethingWrong)
            {
                context.Result = GetSomeUnhappyResult();
            }
        }
    }
