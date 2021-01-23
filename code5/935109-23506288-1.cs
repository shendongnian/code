	// http://stackoverflow.com/questions/14528779/use-camel-case-serialization-only-for-specific-actions
	// This code allows the controller method to be decorated to use camel-casing. If you can modify the controller methods, use this approach.
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Web.Http.Filters;
	using Newtonsoft.Json.Serialization;
	public class CamelCasedApiMethodAttribute : ActionFilterAttribute
	{
		private static JsonMediaTypeFormatter _camelCasingFormatter = new JsonMediaTypeFormatter();
		static CamelCasedApiMethodAttribute()
		{
			_camelCasingFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
		public override void OnActionExecuted(HttpActionExecutedContext httpActionExecutedContext)
		{
			var objectContent = httpActionExecutedContext.Response.Content as ObjectContent;
			if (objectContent != null)
			{
				if (objectContent.Formatter is JsonMediaTypeFormatter)
				{
					httpActionExecutedContext.Response.Content = new ObjectContent(objectContent.ObjectType, objectContent.Value, _camelCasingFormatter);
				}
			}
		}
	}
	// Here is an example of how to use it.
	[CamelCasedApiMethod]
	public HttpResponseMessage Get()
	{
		...
	}
