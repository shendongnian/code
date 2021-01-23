    context.AcceptWebSocketRequest(new MyWebSocketHandler());
    public class MyWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection _connections = new WebSocketCollection();
        
        public override void OnOpen()
        {
           _connections.Broadcast("Another One Joined!");
           _connections.Add(this);
           Send("Hello From the Server");
        }
    }
