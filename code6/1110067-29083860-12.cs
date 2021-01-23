	public abstract class ExtendedController : Controller {
		protected MyDbContext Context {
			get { return RepositoryProxy.Context; }
		}
		protected override void OnActionExecuted(ActionExecutedContext filterContext) {
			RepositoryProxy.SaveIfContext();
			base.OnActionExecuted(filterContext);
		}
	}
