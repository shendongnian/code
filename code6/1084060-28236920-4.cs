    public struct YieldAwaiter : ICriticalNotifyCompletion, INotifyCompletion
    {
        public void OnCompleted(Action continuation);
        public void UnsafeOnCompleted(Action continuation);
        public void GetResult();
        public bool IsCompleted { get; }
    }
