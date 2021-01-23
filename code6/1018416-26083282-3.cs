    public class Modem
    {
        private BlockingCollection<Task> _tasks;
        public Modem()
        {
           _tasks = new BlockingCollection<Task>();
        }
    
        public void QueueTask(Task s)
        {
            _tasks.Add(s);
        }
    
        private Task StartHandleTasks()
        {
             return Task.Run(() =>
             {
                 while (!_tasks.IsCompleted)
                 {
                     Task task;
                     _tasks.TryTake(out task);
                     
                     if (task != null)
                     {
                        // Process item.
                     }
                 }
             });
        }
    }
