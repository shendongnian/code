    public class FeedHub : Hub
        
    {   
        static string username = ""; 
     
        public override Task OnConnected() //event to fire whenever someone joins
        {
        var name = Context.ConnectionId;//capture the unique incoming connection id
        var username = name;//write it into the static string
        return base.OnConnected();
        }
        public override Task OnDisconnected() //event to fire whenever someone quits
        {
        //In here Context.User property is sometimes null because you only recognize authorized users.
        return base.OnDisconnected();
        }
    }
