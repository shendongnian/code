    public class WeakEventListener : IWeakEventListener
    {
        private readonly WeakReference _handlerReference;
        public WeakEventListener(EventHandler handler)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            _handlerReference = new WeakReference(handler);
        }
        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            EventHandler handler = _handlerReference.Target as EventHandler;
            if (handler == null) return false;
            handler(sender, e);
            return true;
        }
    }
