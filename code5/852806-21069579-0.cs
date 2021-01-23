    [HubName("myhub")]
    [Authorize]
    public class MyHub1 : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            var request = Context.Request;
            Clients.Client(Context.ConnectionId).sayhello("Hello " + identity.Name);
            return base.OnConnected();
        }
    }
