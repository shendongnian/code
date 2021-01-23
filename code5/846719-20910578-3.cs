    public class MyHub : Hub
    {
        public static ConcurrentDictionary<string, MyUserType> MyUsers = new ConcurrentDictionary<string, MyUserType>();
        public override Task OnConnected()
        {
            MyUsers.TryAdd(Context.ConnectionId, new MyUserType() { ConnectionId = Context.ConnectionId });
            return base.OnConnected();
        }
        public override Task OnDisconnected()
        {
            MyUserType garbage;
            MyUsers.TryRemove(Context.ConnectionId, out garbage);
            return base.OnDisconnected();
        }
   
        public void PushData(){
            //Values is copy-on-read but Clients.Clients expects IList, hence ToList()
            Clients.Clients(MyUsers.Keys.ToList()).ClientBoundEvent(data);
        }
    }
    public class MyUserType
    {
        public string ConnectionId { get; set; }
        // Can have whatever you want here
    }
    // Your external procedure then has access to all users via MyHub.MyUsers
