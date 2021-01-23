    public class MyHub : Hub
    {
        public static ICommunicationOwner Owner;
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
        public override Task OnConnected()
        {
            Owner.GetData("Client connected: ", Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool graceFull)
        {
            Owner.GetData("Client disconnected: ", Context.ConnectionId);
            return base.OnDisconnected(graceFull);
        }
    }
