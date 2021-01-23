    public class PushNotificationHub : Hub {        
        public void Send(string name, string message) {
            ChatService.ChatUsers[Context.ConnectionId].AddMessage(message);
            Clients.All.addMessage(name, message);
        }
        public override Task OnConnected() {
            ChatService.Current.LogMessage($"Client connected: {Context.ConnectionId}");
            ChatService.ChatUsers.Add(Context.ConnectionId, new Common.ChatUser(Context.QueryString["name"]));
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled) {
            //Application.Current.Dispatcher.Invoke(() => ((MainWindow)Application.Current.MainWindow).LogMessage($"Client disconnected: {Context.ConnectionId}"));
            ChatService.Current.LogMessage($"Client disconnected: {Context.ConnectionId}");
            ChatService.Current.LogMessage(ChatService.ChatUsers[Context.ConnectionId].PrintLog());
            return base.OnDisconnected(stopCalled);
        }
    }
