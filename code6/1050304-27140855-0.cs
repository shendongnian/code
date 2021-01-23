    public static class TaskExt
    {
        // Generic Task<TResult>
        public static IgnoreContextAwaiter<TResult> IgnoreContext<TResult>(this Task<TResult> @task)
        {
            return new IgnoreContextAwaiter<TResult>(@task);
        }
        public struct IgnoreContextAwaiter<TResult> :
            System.Runtime.CompilerServices.ICriticalNotifyCompletion
        {
            Task<TResult> _task;
            public IgnoreContextAwaiter(Task<TResult> task)
            {
                _task = task;
            }
            // custom Awaiter methods
            public IgnoreContextAwaiter<TResult> GetAwaiter()
            {
                return this;
            }
            public bool IsCompleted
            {
                get { return _task.IsCompleted; }
            }
            public TResult GetResult()
            {
                // result and exceptions
                return _task.GetAwaiter().GetResult();
            }
            // INotifyCompletion
            public void OnCompleted(Action continuation)
            {
                // not always synchronous, http://blogs.msdn.com/b/pfxteam/archive/2012/02/07/10265067.aspx
                _task.ContinueWith(_ => continuation(), TaskContinuationOptions.ExecuteSynchronously);
            }
            // ICriticalNotifyCompletion
            public void UnsafeOnCompleted(Action continuation)
            {
                // why SuppressFlow? http://blogs.msdn.com/b/pfxteam/archive/2012/02/29/10274035.aspx
                using (ExecutionContext.SuppressFlow())
                {
                    OnCompleted(continuation);
                }
            }
        }
        // Non-generic Task
        public static IgnoreContextAwaiter IgnoreContext(this Task @task)
        {
            return new IgnoreContextAwaiter(@task);
        }
        public struct IgnoreContextAwaiter :
            System.Runtime.CompilerServices.ICriticalNotifyCompletion
        {
            Task _task;
            public IgnoreContextAwaiter(Task task)
            {
                _task = task;
            }
            // custom Awaiter methods
            public IgnoreContextAwaiter GetAwaiter()
            {
                return this;
            }
            public bool IsCompleted
            {
                get { return _task.IsCompleted; }
            }
            public void GetResult()
            {
                // result and exceptions
                _task.GetAwaiter().GetResult();
            }
            // INotifyCompletion
            public void OnCompleted(Action continuation)
            {
                // not always synchronous, http://blogs.msdn.com/b/pfxteam/archive/2012/02/07/10265067.aspx
                _task.ContinueWith(_ => continuation(), TaskContinuationOptions.ExecuteSynchronously);
            }
            // ICriticalNotifyCompletion
            public void UnsafeOnCompleted(Action continuation)
            {
                // why SuppressFlow? http://blogs.msdn.com/b/pfxteam/archive/2012/02/29/10274035.aspx
                using (ExecutionContext.SuppressFlow())
                {
                    OnCompleted(continuation);
                }
            }
        }
    }
