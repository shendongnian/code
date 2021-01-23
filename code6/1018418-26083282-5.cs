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
    
        private async Task StartHandleTasks()
        {
             return Task.Run(async () =>
             {
                 while (!_tasks.IsCompleted)
                 {
                     if (_tasks.Count == 0)
                     {
                         await Task.Delay(100).ConfigureAwait(false);
                         continue;
                     }
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
