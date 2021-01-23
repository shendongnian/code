    public class MyTask
    {
        private readonly TaskCompletionSource<Task> completionSource = new TaskCompletionSource<Task>();
        private readonly Task[] tasks;
        private int numberOfTasks;
        private MyTask(Task[] tasks)
        {
            if (tasks.Length == 0)
            {
                throw new ArgumentException("No tasks");
            }
            this.tasks = tasks;
            this.numberOfTasks= tasks.Length;
        }
        private int WaitAnyInternal()
        {
            foreach (var task in tasks)
            {
                task.ContinueWith(task1 => completionSource.TrySetResult(task1), TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            foreach (var task in tasks)
            {
                task.ContinueWith(task1 =>
                {
                    if (Interlocked.Decrement(ref numberOfTasks) == 0)
                    {
                        completionSource.SetCanceled();
                    }
                }, TaskContinuationOptions.NotOnRanToCompletion);
            }
            try
            {
                completionSource.Task.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.Flatten().InnerExceptions.OfType<OperationCanceledException>().Any())
                {
                    return -1;
                }
            }
            return Array.IndexOf(tasks, completionSource.Task.Result);
        }
        public static int WaitAnyRanToCompletion(params Task[] tasks)
        {
            return new MyTask(tasks).WaitAnyInternal();
        }
    }
