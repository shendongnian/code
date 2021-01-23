    public class HubPersistentConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "It's connected.");
        }
        // Override more method here
    }
