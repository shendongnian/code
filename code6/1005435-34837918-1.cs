    public class MessagingController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var currentContext = HttpContext.Current;
            if (currentContext.IsWebSocketRequest ||
                currentContext.IsWebSocketRequestUpgrading)
            {
                currentContext.AcceptWebSocketRequest(ProcessWebsocketSession);
            }
            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
        }
        private Task ProcessWebsocketSession(AspNetWebSocketContext context)
        {
            var handler = new MyWebSocketHandler();
            var processTask = handler.ProcessWebSocketRequestAsync(context);
            return processTask;
        }
    }
