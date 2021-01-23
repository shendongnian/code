    public class PriorityDispatcherScheduler : DispatcherScheduler
    {
        private readonly DispatcherPriority _priority;
        public PriorityDispatcherScheduler(DispatcherPriority priority)
            : this(priority, Dispatcher.CurrentDispatcher) {}
        public PriorityDispatcherScheduler(DispatcherPriority priority, Dispatcher dispatcher)
            : base(dispatcher)
        {
            _priority = priority;
        }
        public override IDisposable Schedule<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            var d = new SingleAssignmentDisposable();
            this.Dispatcher.BeginInvoke(
                _priority,
                (Action)(() =>
                         {
                             if (d.IsDisposed)
                                 return;
                             d.Disposable = action(this, state);
                         }));
            return d;
        }
    }
