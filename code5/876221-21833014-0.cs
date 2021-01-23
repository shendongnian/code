    public static class ThreadedWeakEventManager
    {
        private static readonly TimeSpan CleanupInterval = TimeSpan.FromSeconds(10.0);
        private static readonly List<IInternalWeakEventManager> EventManagers = new List<IInternalWeakEventManager>();
        private static volatile bool PerformCleanup = true;
        static ThreadedWeakEventManager()
        {
            new Thread(Cleanup) { IsBackground = true }.Start();
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
        public static void CancelCleanup()
        {
            PerformCleanup = false;
        }
        private static void Cleanup()
        {
            while (PerformCleanup)
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
            IWeakEventData EventData { get; }
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
            public void OnEvent(object sender, EventArgs args)
            {
                this.EventData.ForwardEvent(sender, args);
            }
        }
        private interface IWeakEventData
        {
            bool IsGarbageCollected { get; }
            object EventSource { get; }
            void ForwardEvent(object sender, EventArgs args);
        }
        private class WeakEventData<TEventArgs> : IWeakEventData
            where TEventArgs : EventArgs
        {
            private readonly WeakReference _eventSource;
            private readonly WeakReference _eventTargetInstance;
            private readonly WeakReference _eventHandler;
            public WeakEventData(object eventSource, EventHandler<TEventArgs> eventHandler)
            {
                this._eventSource = new WeakReference(eventSource);
                this._eventTargetInstance = new WeakReference(eventHandler.Target);
                this._eventHandler = new WeakReference(eventHandler);
            }
            public object EventSource { get { return this._eventSource.Target; } }
            public bool IsGarbageCollected
            {
                get
                {
                    return !this._eventSource.IsAlive || !this._eventTargetInstance.IsAlive || !this._eventHandler.IsAlive;
                }
            }
            public void ForwardEvent(object sender, EventArgs args)
            {
                var eventHandler = this._eventHandler.Target as EventHandler<TEventArgs>;
                if (eventHandler != null)
                {
                    eventHandler(sender, (TEventArgs)args);
                }
            }
        }
    }
