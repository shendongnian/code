    // the current pending task (initially a completed stub)
    Task _pendingTask = Task.FromResult<bool>(true);
    
    async void button_Click(object sender, RoutedEventArgs e)
    {
        var previousTask = _pendingTask;
    
        _pendingTask = Task.Run(async () =>
        {
            await previousTask;
    
            Console.WriteLine("start");
            Thread.Sleep(5000);
            Console.WriteLine("end");
        });
    
        // the following "await" is optional, 
        // you only need it if you have other things to do 
        // inside "button_Click" when "_pendingTask" is completed
        await _pendingTask;
    }
