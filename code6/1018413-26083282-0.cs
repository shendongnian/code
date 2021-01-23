    public class Modem
    {
        private BlockingCollection<Task> _tasks;
        public Modem()
        {
           _tasks = new BlockingCollection<Task>();
        }
    
        public void DoTask(Task s)
        {
            _tasks.Add(s);
        }
    
        private void StartHandleTasks()
        {
             Task.Run(() = >
             {
                 while (!_tasks.IsCompleted)
                 {
                     Task task;
                     _tasks.TryTake(out t);
                     
                     if (task != null)
                     {
                        // Process item.
                     }
                 }
             }
        }
    }
