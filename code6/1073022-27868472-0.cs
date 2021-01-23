    using Microsoft.AspNet.SignalR.Hubs;
    public class MyHub : Hub
    {
        [HubMethodName("Hello")]
        public void Hello()
        {
            Clients.All.Hello();
        }
    }
