	public class BaseController : Controller {
		protected HttpNotFoundResult SiteNotFound(string statusDescription = null)
	        {
	            return new HttpNotFoundResult(statusDescription);
	        }
	}
