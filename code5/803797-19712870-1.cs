    public class RoutingEngine : IRoutingEngine
    {
        private readonly IMessageRouters _messageRouters; 
        public RoutingEngine(IMessageRouters messageRouters)
        {
            _messageRouters = messageRouters; 
        }
        public void Route<T>(T inbound)
        {
            var messageRouters = _messageRouters.For(inbound); 
            foreach(var router in messageRouters)
                router.Route(inbound); 
        }
    }
