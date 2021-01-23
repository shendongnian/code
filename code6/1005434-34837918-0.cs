    public class MyWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        public override void OnOpen()
        {
            clients.Add(this);
        }
        public override void OnMessage(string message)
        {
            Send("Echo: " + message);
        }
    }
