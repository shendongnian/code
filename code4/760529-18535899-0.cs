    public class BaseController : Controller
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var actionResult = filterContext.Result;
            var viewResult = actionResult as ViewResult;
            if (viewResult != null)
            {
                var model = viewResult.Model as BaseModel;
                if (model != null)
                {
                    model.Session = GetSession();
                }
            }
            base.OnResultExecuting(filterContext);
        }
    }
