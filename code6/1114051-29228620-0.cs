    [HubName("notifier")]
    public class NotifierHub : Hub
    {
        public void Notify(string message)
        {
            Clients.User("1").Notify(message + " from Hub itself");
            GlobalHost
                .ConnectionManager
                .GetHubContext<NotifierHub>()
                .Clients
                .User("1")
                .Notify(notification.Message + " from ConnectionManager");
        }
    }
