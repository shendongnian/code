    private Task<TState> NextChunk(...)
    {
        return TaskExt.WithNoContext(async() => 
        {
            var nextState = await enumerable.GetMore(...);
            // ...
            return nextState;
        });
    }
    public static class TaskExt
    {
        public static Task<TResult> WithNoContext<TResult>(Func<Task<TResult>> func)
        {
            Task<TResult> task;
            var sc = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                task = func(); // do not await here
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(sc);
            }
            return task;
        }
    }
