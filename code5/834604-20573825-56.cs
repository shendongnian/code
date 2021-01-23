    public class MyAwaiter<TResult> : INotifyCompletion
    {
        public bool IsCompleted { get { ... } }
        public void OnCompleted(Action continuation) { ... }
        public TResult GetResult() { ... }
    }
    //or
    public class MyAwaiter : INotifyCompletion
    {
        public bool IsCompleted { get { ... } }
        public void OnCompleted(Action continuation) { ... }
        public void GetResult() { ... }
    }
