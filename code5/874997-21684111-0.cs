    public class TaskQueue
    {
        private Task currentlyExecuting = Task.FromResult(false);
        public Task continuation = null;
        private Action nextTask = null;
        private object key = new object();
        public Task Queue(Action action)
        {
            lock (key)
            {
                if (nextTask == null)
                {
                    nextTask = action;
                    continuation = currentlyExecuting.ContinueWith(t =>
                        {
                            lock (key)
                            {
                                currentlyExecuting = Task.Run(nextTask);
                                nextTask = null;
                            }
                        });
                    return continuation;
                }
                else
                {
                    nextTask = action;
                    return continuation;
                }
            }
        }
    }
