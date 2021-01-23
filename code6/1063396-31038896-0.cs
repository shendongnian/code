    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        public override Task OnConnected()
        {
            if (Context.QueryString["transport"] == "webSockets")
            {
                return Clients.Caller.changeTransport("longPolling");
            }
        }
    }
