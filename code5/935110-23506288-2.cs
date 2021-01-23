	// http://stackoverflow.com/questions/19956838/force-camalcase-on-asp-net-webapi-per-controller
	// This code allows the entire controller to be decorated to use camel-casing. If you can modify the entire controller, use this approach.
	using System;
	using System.Linq;
	using System.Net.Http.Formatting;
	using System.Web.Http.Controllers;
	using Newtonsoft.Json.Serialization;
	public class CamelCasedApiControllerAttribute : Attribute, IControllerConfiguration
	{
		public void Initialize(HttpControllerSettings httpControllerSettings, HttpControllerDescriptor httpControllerDescriptor)
		{
			var jsonMediaTypeFormatter = httpControllerSettings.Formatters.OfType<JsonMediaTypeFormatter>().Single();
			httpControllerSettings.Formatters.Remove(jsonMediaTypeFormatter);
			jsonMediaTypeFormatter = new JsonMediaTypeFormatter
			{
				SerializerSettings =
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				}
			};
			httpControllerSettings.Formatters.Add(jsonMediaTypeFormatter);
		}
	}
	// Here is an example of how to use it.
	[CamelCasedApiController]
	public class SomeController : ApiController
	{
		...
	}
