    Task _pendingTask = Task.FromResult<bool>(true);
    object _pendingTaskLock = new Object();
    
    async void button_Click(object sender, RoutedEventArgs e)
    {
        lock (_pendingTaskLock)
        {
            var previousTask = _pendingTask;
    
            // note the "Task.Run" lambda doesn't stay in the lock
            _pendingTask = Task.Run(async () =>
            {
                await previousTask;
    
                Console.WriteLine("start");
                Thread.Sleep(1000);
                Console.WriteLine("end");
            });
        }
    
        await _pendingTask;
    }
