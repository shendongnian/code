    private ConcurrentQueue<Task<MessageOptions>> _tasks = new ConcurrentQueue<Task<MessageOptions>>();
    private void ProcessMessage(MessageOptions options)
    {
        var t= Task<MessageOptions>.Factory.StartNew(()=>
        {
           //update data row using options object
           return options;
        });    
        _tasks.Enqueue(t);
        Task t1 = t.ContinueWith(_ =>
        {
            // everytime a task finishes, update the UI for all completed tasks from the start of the queue
            Task<MessageOptions> firstInQueue;
            while (_tasks.TryPeek(out firstInQueue) &&
                   firstInQueue.IsCompleted)
            {
                // this alwys runs in the same thread we can be sure the item is still in the queue
                _tasks.TryDequeue(out firstInQueue);
                var taskOptions = firstInQueue.Result;
                //here goes the code to update the MainUI
            }
        }
        ,TaskScheduler.FromCurrentSynchronizationContext());
     }
