    public class MyAwaitable
    {
        public bool IsAwaited;
        public MyAwaiter GetAwaiter()
        {
            return new MyAwaiter(this);
        }
    }
    public class MyAwaiter
    {
        private readonly MyAwaitable _awaitable;
        public MyAwaiter(MyAwaitable awaitable)
        {
            _awaitable = awaitable;
        }
        public bool IsCompleted
        {
            get { return false; }
        }
        public void GetResult() {}
        public void OnCompleted(Action continuation)
        {
            _awaitable.IsAwaited = true;
        }
    }
