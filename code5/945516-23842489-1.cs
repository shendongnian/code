    public class ContosoChatHub : Hub
    {
        public static NewContosoChatMessage(string message)
        {
            Clients.All.NewMessage(message);
        }
    }
