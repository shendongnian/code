    using System.Collections.Concurrent;
    using System.Diagnostics;
   
    public class EventAggregator
    {
        private readonly ConcurrentDictionary<Type, List<Subscriber>> subscribers =
            new ConcurrentDictionary<Type, List<Subscriber>>();
        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            if (handler == null)
                throw new ArgumentNullException("handler");
            var messageType = typeof(TMessage);
            var handlers = this.subscribers.GetOrAdd(messageType, key => new List<Subscriber>());
            lock(handlers)
            {
                handlers.Add(new Subscriber(handler));
            }
        }
        public void Publish(object message)
        {
            if (message == null)
                throw new ArgumentNullException("message");
    
            var messageType = message.GetType();
            
            List<Subscriber> handlers;
            if (this.subscribers.TryGetValue(messageType, out handlers))
            {
                Subscriber[] tmpHandlers;
                lock(handlers)
                {
                    tmpHandlers = handlers.ToArray();
                }
                
                foreach (var handler in tmpHandlers)
                {
                    if (!handler.Invoke(message))
                    {
                        lock(handlers)
                        {
                            handlers.Remove(handler);
                        }
                    }
                }
            }
        }
        private class Subscriber
        {
            private readonly WeakReference reference;
            private readonly Delegate method;
    
            public Subscriber(Delegate subscriber)
            {
                var target = subscriber.Target;
                
                if (target != null)
                {
                    // An instance method. Capture the target in a WeakReference.
                    // Construct a new delegate that does not have a target;
                    this.reference = new WeakReference(target);
                    var messageType = subscriber.Method.GetParameters()[0].ParameterType;
                    var delegateType = typeof(Action<,>).MakeGenericType(target.GetType(), messageType);
                    this.method = Delegate.CreateDelegate(delegateType, subscriber.Method);
                }
                else
                {
                    // It is a static method, so there is no associated target. 
                    // Hold a strong reference to the delegate.
                    this.reference = null;
                    this.method = subscriber;
                }
                
                Debug.Assert(this.method.Target == null, "The delegate has a strong reference to the target.");
            }
    
            public bool IsAlive
            {
                get
                {
                    // If the reference is null it was a Static method
                    // and therefore is always "Alive".
                    if (this.reference == null)
                        return true;
                    
                    return this.reference.IsAlive;
                }
            }
            
            public bool Invoke(object message)
            {
                object target = null;
                if (reference != null)
                    target = reference.Target;
                
                if (!IsAlive)
                    return false;
                
                if (target != null)
                {
                    this.method.DynamicInvoke(target, message);
                }
                else
                {   
                    this.method.DynamicInvoke(message);
                }
                
                return true;                
            }
        }
    }
