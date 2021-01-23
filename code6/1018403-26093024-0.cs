    foreach (Server server in Servers)
    {
        Server tmpServer = server;
        Task<ListViewItem> mainTask = Task.Factory.StartNew<ListViewItem>(() =>
        {
            return GetMonitorData(tmpServer);
        });
    
        Task contTask = mainTask.ContinueWith(task =>
        {
            lstServers.Items.Add(task.Result);
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
