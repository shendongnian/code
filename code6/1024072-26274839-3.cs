    public class WSHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(ProcessWSChat);
            }
        }
        readonly ConcurrentDictionary<IPrincipal, WebSocket> _users = new ConcurrentDictionary<IPrincipal, WebSocket>();
        
        private async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[4096]);
            //Identify user by cookie or whatever and create a user Object
            var cookie = context.Cookies["mycookie"];
            var url = context.RequestUri;
            IPrincipal myUser = GetUser(cookie, url);
            // Or uses the user that came from the ASP.NET authentication.
            myUser = context.User;
            _users.AddOrUpdate(myUser, socket, (p, w) => socket);
            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None)
                                                            .ConfigureAwait(false);
                String userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                userMessage = "You sent: " + userMessage + " at " +
                    DateTime.Now.ToLongTimeString() + " from ip " + context.UserHostAddress.ToString();
                var sendbuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMessage));
                await socket.SendAsync(sendbuffer , WebSocketMessageType.Text, true, CancellationToken.None)
                            .ConfigureAwait(false);
            }
            // when the connection ends, try to remove the user
            WebSocket ows;
            if (_users.TryRemove(myUser, out ows))
            {
                if (ows != socket)
                {
                    // whops! user reconnected too fast and you are removing
                    // the new connection, put it back
                    _users.AddOrUpdate(myUser, ows, (p, w) => ows);
                }
            }
        }
        private IPrincipal GetUser(HttpCookie cookie, Uri url)
        {
            throw new NotImplementedException();
        }
    }
