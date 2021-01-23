    public class MessagesHub : Hub
        {
            private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            public void Hello()
            {
                Clients.All.hello();
            }
    
            [HubMethodName("sendMessages")]
            public static void SendMessages()
            {
                IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
                context.Clients.All.updateMessages();
            }
    
    
        }
