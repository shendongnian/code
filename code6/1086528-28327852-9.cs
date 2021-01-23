    public class GotWeakEvent
    {
        // Keeps strong references to the IWeakEventListeners until it's
        // identified that the handlers are gone (GC collected). The check happens when 
        // the event is raised or a handler is detached. 
        // If it's never raised an nothing detaches then it leaks
        // the WeakReference objects and the listeners.
        private readonly List<Tuple<WeakReference, WeakEventListener>> _listeners = new List<Tuple<WeakReference, WeakEventListener>>();
        private event EventHandler InternalMyWeakEvent;
        public event EventHandler MyWeakEvent
        {
            add
            {
                WeakEventListener l = new WeakEventListener(value);
                WeakReference wr = new WeakReference(value);
                lock (_listeners)
                {
                    _listeners.Add(new Tuple<WeakReference, WeakEventListener>(wr, l));
                }
                PrivateManager.AddListener(this, l);
            }
            remove
            {
                // remove the reference from the listeners list 
                lock (_listeners)
                {
                    for (int i = _listeners.Count - 1; i >= 0; i--)
                    {
                        var tuple = _listeners[i];
                        if (!tuple.Item1.IsAlive)
                        {
                            _listeners.RemoveAt(i);
                        }
                        else if ((EventHandler)tuple.Item1.Target == value)
                        {
                            PrivateManager.RemoveListener(this, tuple.Item2);
                            _listeners.RemoveAt(i);
                        }
                    }
                }
            }
        }
        protected void RaiseMyWeakEvent()
        {
            // clear dead references
            lock (_listeners)
            {
                for (int i = _listeners.Count - 1; i >= 0; i--)
                {
                    var tuple = _listeners[i];
                    if (!tuple.Item1.IsAlive)
                    {
                        _listeners.RemoveAt(i);
                    }
                }
            }
            var handler = InternalMyWeakEvent;
            if (handler == null) return;
            handler(this, new EventArgs());
        }
        private class PrivateManager : WeakEventManager
        {
            private static PrivateManager CurrentManager
            {
                get
                {
                    var managerType = typeof(PrivateManager);
                    var manager = GetCurrentManager(managerType) as PrivateManager;
                    if (manager != null) return manager;
                    manager = new PrivateManager();
                    SetCurrentManager(managerType, manager);
                    return manager;
                }
            }
            public static void AddListener(GotWeakEvent source, IWeakEventListener listener)
            {
                CurrentManager.ProtectedAddListener(source, listener);
            }
            public static void RemoveListener(GotWeakEvent source, IWeakEventListener listener)
            {
                CurrentManager.ProtectedRemoveListener(source, listener);
            }
            protected override void StartListening(object source)
            {
                ((GotWeakEvent)source).InternalMyWeakEvent += DeliverEvent;
            }
            protected override void StopListening(object source)
            {
                ((GotWeakEvent)source).InternalMyWeakEvent -= DeliverEvent;
            }
        }
    }
