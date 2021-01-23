    private ConcurrentQueue<Task> _tasks = new ConcurrentQueue<Task>();
    private void ProcessMessage(MessageOptions options)
    {
        Task t= Task.Factory.StartNew(()=>
        {
           //update data row using options object
        });    
        _tasks.Enqueue(t);
        Task t1 = t.ContinueWith(_ =>
        {
            // everytime a task finishes, update the UI for all completed tasks from the start of the queue
            Task firstInQueue;
            // this alwys runs in the same thread so it is safe to peek before dequeue
            while (_tasks.TryPeek(out firstInQueue))
            {
                if (!firstInQueue.IsCompleted)
                    break;
                _tasks.TryDequeue(out firstInQueue);
                //here goes the code to update the MainUI   
            }
        }
        ,TaskScheduler.FromCurrentSynchronizationContext());
     }
