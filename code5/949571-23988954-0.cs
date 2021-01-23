	[AttributeUsage(AttributeTargets.Method)]
	public class AllowReferrerAttribute : System.Web.Http.Filters.ActionFilterAttribute
	{
		public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
		{
			var ctx = (System.Web.HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"];
			var referrer = ctx.Request.UrlReferrer;
			if (referrer != null)
			{
				string refhost = referrer.Host;
				string thishost = ctx.Request.Url.Host;
				if (refhost != thishost)
					ctx.Response.AddHeader("Access-Control-Allow-Origin", string.Format("{0}://{1}", referrer.Scheme, referrer.Authority));
			}
			base.OnActionExecuting(actionContext);
		}
	}
