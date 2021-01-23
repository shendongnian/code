    public class BaseController : Controller
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                var viewModel = viewResult.Model as MasterViewModel;
                if (viewModel != null)
                {
                    viewModel.Session = GetSession();
                }
            }
            base.OnResultExecuting(filterContext);
        }
    }
