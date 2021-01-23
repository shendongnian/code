    public class TaskQueue
    {
        private Task currentlyExecuting = Task.FromResult(false);
        public Task continuation = null;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Action nextTask = null;
        private object key = new object();
        public Task Queue(Action action)
        {
            lock (key)
            {
                if (nextTask == null)
                {
                    nextTask = action;
                    ScheduleContinuation();
                    return continuation;
                }
                else
                {
                    nextTask = action;
                    cts.Cancel();
                    ScheduleContinuation();
                    return continuation;
                }
            }
        }
        private void ScheduleContinuation()
        {
            cts = new CancellationTokenSource();
            continuation = currentlyExecuting.ContinueWith(t =>
            {
                lock (key)
                {
                    currentlyExecuting = Task.Run(nextTask);
                    nextTask = null;
                }
            }, cts.Token);
        }
    }
