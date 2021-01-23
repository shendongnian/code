	public class SessionAuthorizeAttribute : AuthorizeAttribute
	{
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			return httpContext.Session["InsuredKey"] != null;
		}
	}
