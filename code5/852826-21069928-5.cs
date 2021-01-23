    using System.Collections.Generic;
    using System.Linq;
    private static Dictionary<string, List<string>> userGroups 
                                     = new Dictionary<string, List<string>>()
    private static object _lock = new object();
    
    public class NotificationHub : Hub
    {
        public void ShowSelfNotification(string page, string type, int id, string title)
        {
            string username = Context.User.Identity.Name;
            Clients.Group(username).broadcastNotification(page, type, id, title);
        }
    
        public void ShowNotification(string page, string type, int id, string title)
        {
            string username = Context.User.Identity.Name;
            var others = userGroups.Where(n => n.Key != username)
                                   .SelectMany(s => s.Value);
            Clients.AllExcept(others.ToArray())
                   .broadcastNotification(username, page, type, id, title);
        }
    
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            Groups.Add(Context.ConnectionId, name);
            lock(_lock)
            {
                if (userGroups .ContainsKey(name))
                    userGroups [name].Add(Context.ConnectionId);
                else
                    userGroups .Add(name, new List<string>{Context.ConnectionId})
            }
            return base.OnConnected();
        }
       public override Task OnDisconnected()
       {
           string name = Context.User.Identity.Name;
           lock(_lock)
           {
                if (userGroups .ContainsKey(name))
                    userGroups[name].Remove(Context.ConnectionId);
           }
           return base.OnDisconnected();
       }
    }
 
