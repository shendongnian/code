    public class YourHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.addMessageToConsole(message);
        }
    }
