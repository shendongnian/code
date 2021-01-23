    public class WeakEventHandler<TE> where TE : EventArgs
    {
        private delegate void OpenEventHandler(object target, object sender, TE e);
        private readonly WeakReference _targetRef;
        private readonly OpenEventHandler _openHandler;
        private readonly Action<WeakEventHandler<TE>> _unsubscriber;
        private readonly EventHandler<TE> _handler;
        public WeakEventHandler(EventHandler<TE> subscriber, Action<WeakEventHandler<TE>> unsubscriber)
        {
            _unsubscriber = unsubscriber;
            _targetRef = new WeakReference(subscriber.Target);
            _handler = Invoke;
            var target = Expression.Parameter(typeof (object), "target");
            var sender = Expression.Parameter(typeof(object), "sender");
            var args = Expression.Parameter(typeof (TE), "args");
            _openHandler =
                Expression.Lambda<OpenEventHandler>(
                    Expression.Call(Expression.Convert(target, subscriber.Target.GetType()), subscriber.Method, sender,
                        args),target,sender,args).Compile();
        }
        public void Invoke(object sender, TE e)
        {
            var t = _targetRef.Target;
            if (t != null)
            {
                _openHandler(t, sender, e);
            }
            else
            {
                _unsubscriber(this);
            }
        }
        public static implicit operator EventHandler<TE>(WeakEventHandler<TE> weh)
        {
            return weh._handler;
        }
    }
