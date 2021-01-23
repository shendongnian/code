    public class WSHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
    
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(ProcessWS);
            }
        }
    
        private async Task ProcessWS(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            
            ...
    
            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None)
                                                            .ConfigureAwait(false);
                
                ...
            }
        }
    }
