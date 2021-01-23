    public class EventHandlerRegistry : IDisposable
    {
        private ConcurrentDictionary<Type, List<IDisposable>> _registrations;
        public EventHandlerRegistry()
        {
            _registrations = new ConcurrentDictionary<Type, List<IDisposable>>();
        }
        public void RegisterHandlerFor(object target, EventInfo evtInfo, Action eventHandler)
        {
            var evtType = evtInfo.EventHandlerType.GetGenericArguments()[0];
            _registrations.AddOrUpdate(
                evtType,
                (t) => new List<IDisposable>() { ConstructHandler(target, evtType, evtInfo, eventHandler) },
                (t, l) => { l.Add(ConstructHandler(target, evtType, evtInfo, eventHandler)); return l; });
        }
        public IDisposable CreateUnregisteredHandlerFor(object target, EventInfo evtInfo, Action eventHandler)
        {
            var evtType = evtInfo.EventHandlerType.GetGenericArguments()[0];
            return ConstructHandler(target, evtType, evtInfo, eventHandler);
        }
        public void Dispose()
        {
            var regs = Interlocked.Exchange(ref _registrations, null);
            if (regs != null)
            {
                foreach (var reg in regs.SelectMany(r => r.Value))
                    reg.Dispose();
            }
        }
        private IDisposable ConstructHandler(object target, Type evtType, EventInfo evtInfo, Action eventHandler)
        {
            var handlerType = typeof(HandlerFor<>).MakeGenericType(evtType);
            return Activator.CreateInstance(handlerType, target, evtInfo, eventHandler) as IDisposable;
        }
        private class HandlerFor<T> : IDisposable where T : EventArgs
        {
            private readonly Action _eventAction;
            private readonly EventInfo _evtInfo;
            private readonly object _target;
            private EventHandler<T> _registeredHandler;
            public HandlerFor(object target, EventInfo evtInfo, Action eventAction)
            {
                _eventAction = eventAction;
                _evtInfo = evtInfo;
                _target = target;
                _registeredHandler = new EventHandler<T>(this.Handle);
                _evtInfo.AddEventHandler(target, _registeredHandler);
            }
            public void Unregister()
            {
                var registered = Interlocked.Exchange(ref _registeredHandler, null);
                if (registered != null)
                    // Unregistration is awkward: 
                    // doing `RemoveEventHandler(_target, registered);` won't work.
                    _evtInfo.RemoveEventHandler(_target, new EventHandler<T>(this.Handle));
            }
            private void Handle(object sender, T EventArgs)
            {
                if (_eventAction != null)
                    _eventAction();
            }
            public void Dispose()
            {
                Unregister();
            }
        }
    }
