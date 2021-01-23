    public class WeakEventListener : IWeakEventListener
    {
        private readonly EventHandler _handler;
    
        public WeakEventListener(EventHandler handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            _handler = handler;
        }
    
        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            _handler(sender, e);
            return true;
        }
    }
