    public class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy(Func<Task<T>> taskFactory, LazyThreadSafetyMode mode) :
            base(() => Task.Factory.StartNew(() => taskFactory()).Unwrap(), mode)
        { }
    
        public TaskAwaiter<T> GetAwaiter() { return Value.GetAwaiter(); }
    }
