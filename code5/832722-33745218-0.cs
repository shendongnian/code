     [HubName("headerHub")]
     public class HeaderHub : Hub
     {
        static HeaderHub()
        {
            EventManager.CartUpdated += Update;
            EventManager.LoggedOut += Update;
            EventManager.LoggedIn += Update;
        }
        public override Task OnConnected()
        {
            var group = Context.Request.Cookies["ASP.NET_SessionId"].Value;
            Groups.Add(Context.ConnectionId, group);
            return base.OnConnected();
        }
        private static void Update(object sender, SessionEventArgs e)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<HeaderHub>();
            hubContext.Clients.Group(e.SessionId).onUpdateHeader();
        }
    }
