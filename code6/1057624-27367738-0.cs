	public class BaseController : Controller
	{
		protected string Token { get; private set; }
		
		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			
			string token = Request.QueryString["token"] as string;
			Token = token ?? string.Empty;
		}
	}
