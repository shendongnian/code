        // Generic Task<TResult>
        public static StrongAwaiter<TResult> WithStrongAwaiter<TResult>(this Task<TResult> @task)
        {
            return new StrongAwaiter<TResult>(@task);
        }
        public class StrongAwaiter<TResult> :
            System.Runtime.CompilerServices.ICriticalNotifyCompletion
        {
            Task<TResult> _task;
            System.Runtime.CompilerServices.TaskAwaiter<TResult> _awaiter;
            System.Runtime.InteropServices.GCHandle _gcHandle;
            public StrongAwaiter(Task<TResult> task)
            {
                _task = task;
                _awaiter = _task.GetAwaiter();
            }
            // custom Awaiter methods
            public StrongAwaiter<TResult> GetAwaiter()
            {
                return this;
            }
            public bool IsCompleted
            {
                get { return _task.IsCompleted; }
            }
            public TResult GetResult()
            {
                return _awaiter.GetResult();
            }
            // INotifyCompletion
            public void OnCompleted(Action continuation)
            {
                _awaiter.OnCompleted(WrapContinuation(continuation));
            }
            // ICriticalNotifyCompletion
            public void UnsafeOnCompleted(Action continuation)
            {
                _awaiter.UnsafeOnCompleted(WrapContinuation(continuation));
            }
            Action WrapContinuation(Action continuation)
            {
                Action wrapper = () =>
                {
                    _gcHandle.Free();
                    continuation();
                };
                _gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(wrapper);
                return wrapper;
            }
        }
        // Non-generic Task
        public static StrongAwaiter WithStrongAwaiter(this Task @task)
        {
            return new StrongAwaiter(@task);
        }
        public class StrongAwaiter :
            System.Runtime.CompilerServices.ICriticalNotifyCompletion
        {
            Task _task;
            System.Runtime.CompilerServices.TaskAwaiter _awaiter;
            System.Runtime.InteropServices.GCHandle _gcHandle;
            public StrongAwaiter(Task task)
            {
                _task = task;
                _awaiter = _task.GetAwaiter();
            }
            // custom Awaiter methods
            public StrongAwaiter GetAwaiter()
            {
                return this;
            }
            public bool IsCompleted
            {
                get { return _task.IsCompleted; }
            }
            public void GetResult()
            {
                _awaiter.GetResult();
            }
            // INotifyCompletion
            public void OnCompleted(Action continuation)
            {
                _awaiter.OnCompleted(WrapContinuation(continuation));
            }
            // ICriticalNotifyCompletion
            public void UnsafeOnCompleted(Action continuation)
            {
                _awaiter.UnsafeOnCompleted(WrapContinuation(continuation));
            }
            Action WrapContinuation(Action continuation)
            {
                Action wrapper = () =>
                {
                    _gcHandle.Free();
                    continuation();
                };
                _gcHandle = System.Runtime.InteropServices.GCHandle.Alloc(wrapper);
                return wrapper;
            }
        }
    }
        
