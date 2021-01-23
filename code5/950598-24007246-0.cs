	[AttributeUsage(AttributeTargets.Method)]
	public class AllowReferrerAttribute : ActionFilterAttribute
	{
		/// <summary>Update headers with CORS 'Access-Control-Allow-Origin' as required</summary>
		/// <param name="actionContext">Context of action to work with</param>
		public override void OnActionExecuting(HttpActionContext actionContext)
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
	public class TestController : ApiController
	{
		[AllowReferrer]
		public void Post([FromBody]string value)
		{
			if (value == null)
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			if (value.Length > 100000)
				throw new HttpResponseException(HttpStatusCode.Forbidden);
		}
	}
