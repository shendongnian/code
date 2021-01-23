    public class DispatcherWrapper
    {
        private readonly Action<Action> _dispatch;
        public DispatcherWrapper(Action<Action> dispatch)
        {
            _dispatch = dispatch;
        }
        public void Dispatch(Action action)
        {
            _dispatch(action);
        }
    }
    public class Application
    {
        internal void SomeCode()
        {
            // A UI application would call...
            var dispatcher = Dispatcher.CurrentDispatcher;
            var dispatcherWrapper = new DispatcherWrapper(action => dispatcher.BeginInvoke(action));
            // A non-UI application would call...
            dispatcherWrapper = new DispatcherWrapper(action => action());
            // The library code would call..
            dispatcherWrapper.Dispatch(() => { 
                // This code runs on the UI thread in UI apps and on any thread in non-UI apps.
            });
        }
    }
