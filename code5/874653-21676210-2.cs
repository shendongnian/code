    private async void Start_Click(object sender, RoutedEventArgs e)
    {
        var connectionTasks = new List<Task>();
        Func<Task> handleConnection = async () =>
        {
            var connectionTask = Task.Run(() => HandleAcceptedConnection(handler));
            connectionTasks.Add(connectionTask);
            await connectionTask;
            connectionTasks.Remove(connectionTask);
        };
        var task = Task.Run(() =>
        {
            while (isContinue)
            {
                var handler = listener.Accept();
                // handle connection
                Log("Before");
                Log("ThreadId Accept " + Thread.CurrentThread.ManagedThreadId);
                var connectionTask = handleConnection();
                Log("After");
                isContinue = true;
            }
        });
        await task;
    }
