    public MainWindow()
    {
        InitializeComponent();
        var _ = ProcessURLs();
    }
    public async Task ProcessURLs()
    {
        List<Task<string>> tasks = URLsToProcess.Select(uri => DownloadStringAsTask(new Uri(uri))).ToList();
        while (tasks.Count > 0)
        {
            Task<string> task = await Task.WhenAny(tasks);
            string messageText;
            if (task.Status == TaskStatus.RanToCompletion)
            {
                messageText = string.Format("{0} has completed", task.AsyncState);
                // TODO: do something with task.Result, i.e. the actual downloaded text
            }
            else
            {
                messageText = string.Format("{0} has completed with failure: {1}", task.AsyncState, task.Status);
            }
            this.tbStatusBar.Text = messageText;
            tasks.Remove(task);
        }
        tbStatusBar.Text = "All tasks completed";
    }
