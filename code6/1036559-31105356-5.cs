    public class impAuthHub : Hub
    {
        [Authorize]
        public void SendMessage(string name, string message)
        {
           Clients.All.newMessage(name, message);
        }
    }
