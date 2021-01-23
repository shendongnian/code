    public static class WithOperationContextTaskExtensions
    {
        public static ContinueOnOperationContextAwaiter<TResult> WithOperationContext<TResult>(this Task<TResult> @this, bool configureAwait = true)
        {
            return new ContinueOnOperationContextAwaiter<TResult>(@this, configureAwait);
        }
        public static ContinueOnOperationContextAwaiter WithOperationContext(this Task @this, bool configureAwait = true)
        {
            return new ContinueOnOperationContextAwaiter(@this, configureAwait);
        }
        public class ContinueOnOperationContextAwaiter : INotifyCompletion
        {
            private readonly ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _awaiter;
            private OperationContext _operationContext;
            public ContinueOnOperationContextAwaiter(Task task, bool continueOnCapturedContext = true)
            {
                if (task == null) throw new ArgumentNullException("task");
                _awaiter = task.ConfigureAwait(continueOnCapturedContext).GetAwaiter();
            }
            public ContinueOnOperationContextAwaiter GetAwaiter() { return this; }
            public bool IsCompleted { get { return _awaiter.IsCompleted; } }
            public void OnCompleted(Action continuation)
            {
                _operationContext = OperationContext.Current;
                _awaiter.OnCompleted(continuation);
            }
            public void GetResult()
            {
                OperationContext.Current = _operationContext;
                _awaiter.GetResult();
            }
        }
        public class ContinueOnOperationContextAwaiter<TResult> : INotifyCompletion
        {
            private readonly ConfiguredTaskAwaitable<TResult>.ConfiguredTaskAwaiter _awaiter;
            private OperationContext _operationContext;
            public ContinueOnOperationContextAwaiter(Task<TResult> task, bool continueOnCapturedContext = true)
            {
                if (task == null) throw new ArgumentNullException("task");
                _awaiter = task.ConfigureAwait(continueOnCapturedContext).GetAwaiter();
            }
            public ContinueOnOperationContextAwaiter<TResult> GetAwaiter() { return this; }
            public bool IsCompleted { get { return _awaiter.IsCompleted; } }
            public void OnCompleted(Action continuation)
            {
                _operationContext = OperationContext.Current;
                _awaiter.OnCompleted(continuation);
            }
            public TResult GetResult()
            {
                OperationContext.Current = _operationContext;
                return _awaiter.GetResult();
            }
        }
    }
