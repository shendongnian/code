    Task _currentTask = Task.FromResult(Type.Missing);
    readonly object _lock = new Object();
    void QueueTask(Action action)
    {
        lock (_lock)
        {
            _currentTask = _currentTask.ContinueWith(
                lastTask => 
                {
                    // re-throw the error of the last completed task (if any)
                    lastTask.GetAwaiter().GetResult();
                    // run the new task
                    action();
                },
                CancellationToken.None, 
                TaskContinuationOptions.LazyCancellation, 
                TaskScheduler.Default);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        for(var i = 0; i < 10; i++)
        {
            var sleep = 1000 - i*100;
            QueueTask(() => 
            { 
                Thread.Sleep(sleep); 
                Debug.WriteLine("Slept for {0} ms", sleep); 
            });
        }
    }
