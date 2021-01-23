    public static class TaskExt
    {
        public static Task<Empty> AsGeneric(this Task @this)
        {
            return @this.IsCompleted ?
                CompletedAsGeneric(@this) :
                @this.ContinueWith<Task<Empty>>(CompletedAsGeneric, 
                    TaskContinuationOptions.ExecuteSynchronously).Unwrap();
        }
        static Task<Empty> CompletedAsGeneric(Task completedTask)
        {
            try
            {
                if (completedTask.Status != TaskStatus.RanToCompletion)
                    // propagate exceptions
                    completedTask.GetAwaiter().GetResult();
                // return completed task
                return Task.FromResult(Empty.Value);
            }
            catch (OperationCanceledException ex)
            {
                // propagate cancellation
                if (completedTask.IsCanceled)
                    // return cancelled task
                    return new Task<Empty>(() => Empty.Value, ex.CancellationToken);
                throw;
            }
        }
    }
    public struct Empty
    {
        public static readonly Empty Value = default(Empty);
    }
