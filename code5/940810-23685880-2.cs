    public class ActiveTaskTracker
    {
        private HashSet<Task> tasks = new HashSet<Task>();
        public void Add(Task task)
        {
            if (!task.IsCompleted)//short circuit as an optimization
            {
                lock (tasks)
                    tasks.Add(task);
                task.ContinueWith(t => { lock (tasks)tasks.Remove(task); });
            }
        }
        public Task WaitAll()
        {
            lock (tasks)
                return Task.WhenAll(tasks.ToArray());
        }
    }
