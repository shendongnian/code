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
			var ws = context.WebSocket;
            new Task(() =>
            {
                var inputSegment = new ArraySegment<byte>(new byte[1024]);
                while (true)
                {
                    // MUST read if we want the state to get updated...
                    var result = await ws.ReceiveAsync(inputSegment, CancellationToken.None);
                    if (ws.State != WebSocketState.Open)
                    {
                        break;
                    }
                }
            }).Start();
            while (true)
            {
                if (ws.State != WebSocketState.Open)
                {
					break;
                }
                else
                {
					byte[] binaryData = { 0xde, 0xad, 0xbe, 0xef, 0xca, 0xfe };
					var segment = new ArraySegment<byte>(binaryData);
                    await ws.SendAsync(segment, WebSocketMessageType.Binary, 
						true, CancellationToken.None);
                }
            }
		}
	}
