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
                    cts.Cancel();
                    nextTask = action;
                    ScheduleContinuation();
                    return continuation;
                }
            }
        }
        private void ScheduleContinuation()
        {
            cts = new CancellationTokenSource();
            var token = cts.Token;
            continuation = currentlyExecuting.ContinueWith(t =>
            {
                lock (key)
                {
                    currentlyExecuting = Task.Run(nextTask);
                    token.ThrowIfCancellationRequested();
                    nextTask = null;
                }
            }, cts.Token);
        }
    }
