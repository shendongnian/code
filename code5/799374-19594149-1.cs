    public class PriorityDispatcherScheduler : DispatcherScheduler
    {
        private readonly DispatcherPriority _priority;
        public PriorityDispatcherScheduler(DispatcherPriority priority)
            : this(priority, Dispatcher.CurrentDispatcher) { }
        public PriorityDispatcherScheduler(DispatcherPriority priority, Dispatcher dispatcher)
            : base(dispatcher)
        {
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");
            _priority = priority;
        }
        #region Implementation of IScheduler
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
        #endregion
    }
