    public class BaseController : Controller
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                var viewModel = viewResult.Model as ISelectFields;
                if (viewModel != null)
                {
                    viewModel.FooDdl = fooRepository.GetAll().ToSelectList(x => x.Id, x => x.Name)
                }
            }
            base.OnResultExecuting(filterContext);
        }
    }
