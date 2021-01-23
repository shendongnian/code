	// Solution #1 - This is my solution. It updates the JsonMediaTypeFormatter whenever a response is sent to the API call.
	// If you ever need to keep the controller methods untouched, this could be a solution for you.
	using System;
	using System.Net;
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Web.Http;
	using Newtonsoft.Json.Serialization;
	public class CamelCasedApiController : ApiController
	{
		public HttpResponseMessage CreateResponse(object responseMessageContent)
		{
			try
			{
				var httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, responseMessageContent, JsonMediaTypeFormatter.DefaultMediaType);
				var objectContent = httpResponseMessage.Content as ObjectContent;
				if (objectContent != null)
				{
					var jsonMediaTypeFormatter = new JsonMediaTypeFormatter
					{
						SerializerSettings =
						{
							ContractResolver = new CamelCasePropertyNamesContractResolver()
						}
					};
					httpResponseMessage.Content = new ObjectContent(objectContent.ObjectType, objectContent.Value, jsonMediaTypeFormatter);
				}
				return httpResponseMessage;
			}
			catch (Exception exception)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
			}
		}
	}
