    public class MessageRouters : IMessageRouters
    {
        public IList<IMessageRouter> _routers = new List<IMessageRouter>();
        public IEnumerable<IMessageRouter> For<T>(T inbound)
        {
            return _routers.Where(x => x.CanRoute(inbound)); 
        }
        public void Add(IMessageRouter messageRouter)
        {
            _routers.Add(messageRouter); 
        }
    }
