	class MyServiceController : ApiController
	{
		public HttpResponseMessage Get (string param)
		{
			HttpContext currentContext = HttpContext.Current;
			if (currentContext.IsWebSocketRequest || 
				currentContext.IsWebSocketRequestUpgrading)
			{
				currentContext.AcceptWebSocketRequest(ProcessWebsocketSession); 
				return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
			}	
		}
		
		private async Task ProcessWebsocketSession(AspNetWebSocketContext context)
		{
		...
		}
	}
