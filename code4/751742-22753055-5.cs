    public sealed class FlowingOperationContextScope : IDisposable
    {
        bool _inflight = false;
        bool _disposed;
        OperationContext _thisContext = null;
        OperationContext _originalContext = null;
        public FlowingOperationContextScope(IContextChannel channel):
            this(new OperationContext(channel))
        {
        }
        public FlowingOperationContextScope(OperationContext context)
        {
            _originalContext = OperationContext.Current;
            OperationContext.Current = context;
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                if (_inflight || OperationContext.Current != _thisContext)
                    throw new InvalidOperationException();
                _disposed = true;
                OperationContext.Current = _originalContext;
                _thisContext = null;
                _originalContext = null;
            }
        }
        internal void BeforeAwait()
        {
            if (_inflight)
                return;
            _inflight = true;
            // leave _thisContext as the current context
       }
        internal void AfterAwait()
        {
            if (!_inflight)
                throw new InvalidOperationException();
            _inflight = false;
            // ignore the current context, restore _thisContext
            OperationContext.Current = _thisContext;
        }
    }
    // ContinueOnScope extension
    public static class TaskExt
    {
        public static SimpleAwaiter<TResult> ContinueOnScope<TResult>(this Task<TResult> @this, FlowingOperationContextScope scope)
        {
            return new SimpleAwaiter<TResult>(@this, scope.BeforeAwait, scope.AfterAwait);
        }
        // awaiter
        public class SimpleAwaiter<TResult> :
            System.Runtime.CompilerServices.INotifyCompletion
        {
            readonly Task<TResult> _task;
            readonly Action _beforeAwait;
            readonly Action _afterAwait;
            public SimpleAwaiter(Task<TResult> task, Action beforeAwait, Action afterAwait)
            {
                _task = task;
                _beforeAwait = beforeAwait;
                _afterAwait = afterAwait;
            }
            public SimpleAwaiter<TResult> GetAwaiter()
            {
                return this;
            }
            public bool IsCompleted
            {
                get 
                {
                    // don't do anything if the task completed synchronously
                    // (we're on the same thread)
                    if (_task.IsCompleted)
                        return true;
                    _beforeAwait();
                    return false;
                }
            }
            public TResult GetResult()
            {
                return _task.Result;
            }
            // INotifyCompletion
            public void OnCompleted(Action continuation)
            {
                _task.ContinueWith(task =>
                {
                    _afterAwait();
                    continuation();
                },
                TaskContinuationOptions.ExecuteSynchronously,
                SynchronizationContext.Current != null ?
                    TaskScheduler.FromCurrentSynchronizationContext() :
                    TaskScheduler.Current);
            }
        }
    }
