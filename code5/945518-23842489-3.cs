    public class ContosoChatHub : Hub
    {
        public static NewContosoChatMessage(string message)
        {
         var notifyContext = GlobalHost.ConnectionManager.GetHubContext<ContosoChatHub >();
            notifyContext.Clients.All.NewMessage(message);
        }
    }
