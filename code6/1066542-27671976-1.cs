        public class ChatHub : Hub
        {
            private static string waitingUser;
            private static readonly object SyncLock = new object();
            public void SendMessage(string text, string clientId)
            {
                this.Clients.Client(clientId).addMessage(text);
            }
            public override Task OnConnected()
            {
                var newUser = this.Context.ConnectionId;
                string otherUser;
                lock (SyncLock)
                {
                    if (waitingUser == null)
                    {
                        waitingUser = newUser;
                        return base.OnConnected();
                    }
                    otherUser = waitingUser;
                    waitingUser = null;
                }
                this.Clients.Caller.startChat(otherUser);
                this.Clients.Client(otherUser).startChat(newUser);
                return base.OnConnected();
            }
        }
