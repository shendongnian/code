        private async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[4096]);
            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None)
                                                            .ConfigureAwait(false);
                String userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                userMessage = "You sent: " + userMessage + " at " +
                    DateTime.Now.ToLongTimeString() + " from ip " + context.UserHostAddress.ToString();
                buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMessage));
                await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None)
                            .ConfigureAwait(false);
            }
        }
