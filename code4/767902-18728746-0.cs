	public class MvcApplication : HttpApplication {
		protected void Application_EndRequest() {
			var context = new HttpContextWrapper(Context);
			// If we're an ajax request, and doing a 302, then we actually need to do a 401
			if (Context.Response.StatusCode == 302 && context.Request.IsAjaxRequest()) {
				Context.Response.Clear();
				Context.Response.StatusCode = 401;
			}
		}
	}
