    public interface IDispatcher
    {
        void ExecuteOnUIThread(Action action);
        // Add whatever methods you need on this interface
    }
    public static class DispatcherContext
    {
        // An instance that implements IDispatcher can be accessed via this static property
        public static IDispatcher Dispatcher { get; set; }
    }
    // Of course you need to write an adapter for the WPF Dispatcher class
