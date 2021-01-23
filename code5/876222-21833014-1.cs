    public static class ThreadedWeakEventManager
    {
        private static readonly TimeSpan CleanupInterval = TimeSpan.FromSeconds(1.0);
        private static readonly List<IInternalWeakEventManager> EventManagers = new List<IInternalWeakEventManager>();
        private static volatile bool _performCleanup = true;
        static ThreadedWeakEventManager()
        {
            new Thread(Cleanup) { IsBackground = true, Priority = ThreadPriority.Lowest }.Start();
        }
        public static void AddHandler<TEventArgs>(object eventSource, string eventName, EventHandler<TEventArgs> eventHandler)
            where TEventArgs : EventArgs
        {
            var weakEventManager = new InternalWeakEventManager<TEventArgs>(eventSource, eventName, eventHandler);
            lock (EventManagers)
            {
                EventManagers.Add(weakEventManager);
            }
        }
        public static void AddPropertyChangedHandler(INotifyPropertyChanged eventSource, EventHandler<PropertyChangedEventArgs> eventHandler)
        {
            AddHandler(eventSource, "PropertyChanged", eventHandler);
        }
        public static void AddCollectionChangedEventHandler(INotifyCollectionChanged eventSource, EventHandler<NotifyCollectionChangedEventArgs> eventHandler)
        {
            AddHandler(eventSource, "CollectionChanged", eventHandler);
        }
        public static void RemoveHandler<TEventArgs>(object eventSource, string eventName, EventHandler<TEventArgs> eventHandler)
            where TEventArgs : EventArgs
        {
            if (eventSource == null || string.IsNullOrWhiteSpace(eventName) || eventHandler == null)
            {
                return;
            }
            lock (EventManagers)
            {
                EventManagers.RemoveAll(item => object.ReferenceEquals(item.EventData.EventSource, eventSource) && item.EventName.Equals(eventName) && eventHandler.Method.Equals(item.EventData.EventHandlerMethodInfo));
            }
        }
        public static void RemovePropertyChangedHandler(INotifyPropertyChanged eventSource, EventHandler<PropertyChangedEventArgs> eventHandler)
        {
            RemoveHandler(eventSource, "PropertyChanged", eventHandler);
        }
        public static void RemoveCollectionChangedEventHandler(INotifyCollectionChanged eventSource, EventHandler<NotifyCollectionChangedEventArgs> eventHandler)
        {
            RemoveHandler(eventSource, "CollectionChanged", eventHandler);
        }
        public static void CancelCleanup()
        {
            _performCleanup = false;
        }
        private static void Cleanup()
        {
            while (_performCleanup)
            {
                Thread.Sleep(CleanupInterval);
                lock (EventManagers)
                {
                    for (var i = EventManagers.Count - 1; i >= 0; --i)
                    {
                        var item = EventManagers[i];
                        if (item.EventData.IsGarbageCollected)
                        {
                            item.UnwireEvent();
                            EventManagers.RemoveAt(i);
                        }
                    }
                }
            }
        }
        private interface IInternalWeakEventManager
        {
            string EventName { get; }
            IWeakEventData EventData { get; }>
            void UnwireEvent();
            void OnEvent(object sender, EventArgs args);
        }
        private class InternalWeakEventManager<TEventArgs> : IInternalWeakEventManager
            where TEventArgs : EventArgs
        {
            private static readonly MethodInfo OnEventMethodInfo = typeof(InternalWeakEventManager<TEventArgs>).GetMethod("OnEvent");
            private EventInfo _eventInfo;
            private Delegate _onEvent;
            public InternalWeakEventManager(object eventSource, string eventName, EventHandler<TEventArgs> eventHandler)
            {
                this.EventData = new WeakEventData<TEventArgs>(eventSource, eventHandler);
                this.WireEvent(eventSource, eventName);
            }
			
            public string EventName
            {
                get { return this._eventInfo.Name; }
            }
            public IWeakEventData EventData { get; private set; }
            public void UnwireEvent()
            {
                var eventSource = this.EventData.EventSource;
                if (eventSource == null)
                {
                    return;
                }
                this._eventInfo.RemoveEventHandler(eventSource, this._onEvent);
            }
            public void OnEvent(object sender, EventArgs args)
            {
                this.EventData.ForwardEvent(sender, args);
            }
            private void WireEvent(object eventSource, string eventName)
            {
                this._eventInfo = eventSource.GetType().GetEvents().FirstOrDefault(item => item.Name == eventName);
                if (this._eventInfo == null)
                {
                    throw new InvalidOperationException(string.Format("The event source type {0} doesn't contain an event named {1}.", eventSource.GetType().FullName, eventName));
                }
                this._onEvent = Delegate.CreateDelegate(this._eventInfo.EventHandlerType, this, OnEventMethodInfo);
                this._eventInfo.AddEventHandler(eventSource, this._onEvent);
            }
        }
        private interface IWeakEventData
        {
            bool IsGarbageCollected { get; }
            object EventSource { get; }>
            MethodInfo EventHandlerMethodInfo { get; }
            void ForwardEvent(object sender, EventArgs args);
        }
        private class WeakEventData<TEventArgs> : IWeakEventData
            where TEventArgs : EventArgs
        {
            private readonly WeakReference _eventSource;
            private readonly WeakReference _eventTargetInstance;
			
            public WeakEventData(object eventSource, EventHandler<TEventArgs> eventHandler)
            {
                this._eventSource = new WeakReference(eventSource);
                this._eventTargetInstance = new WeakReference(eventHandler.Target);
                this.EventHandlerMethodInfo = eventHandler.Method;
            }
            public object EventSource
            {
                get { return this._eventSource.Target; }
            }
            public MethodInfo EventHandlerMethodInfo { get; private set; }
            public bool IsGarbageCollected
            {
                get
                {
                    return !this._eventSource.IsAlive || !this._eventTargetInstance.IsAlive;
                }
            }
            public void ForwardEvent(object sender, EventArgs args)
            {
                var target = this._eventTargetInstance.Target;
                if (target != null)
                {
                    this.EventHandlerMethodInfo.Invoke(target, new[] { sender, args });
                }
            }
        }
    }
