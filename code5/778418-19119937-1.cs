		public class WrapperHttpResponseMessageResult : ActionResult
		{
			private readonly HttpResponseMessage _response;
			public WrapperHttpResponseMessageResult(HttpResponseMessage response)
			{
				_response = response;
			}
			public override void ExecuteResult(ControllerContext context)
			{
				HttpResponseBase responseContext = context.RequestContext.HttpContext.Response;
				responseContext.StatusCode = (int)_response.StatusCode;
				responseContext.StatusDescription = _response.ReasonPhrase;
				foreach (KeyValuePair<string, IEnumerable<string>> keyValuePair in (HttpHeaders)_response.Headers)
				{
					foreach (string str in keyValuePair.Value)
						responseContext.AddHeader(keyValuePair.Key, str);
				}
				if (_response.Content != null)
				{
					_response.Content.CopyToAsync(responseContext.OutputStream).Wait();
				}
			}
		}
