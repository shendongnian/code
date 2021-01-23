    private void DownloadData()
    {
        var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
        var urLsToProcess = new List<string>
        {
            "http://www.microsoft.com",
            "http://www.stackoverflow.com",
            "http://www.google.com",
            "http://www.apple.com",
            "http://www.ebay.com",
            "http://www.oracle.com",
            "http://www.gmail.com",
            "http://www.amazon.com",
            "http://www.outlook.com",
            "http://www.yahoo.com",
            "http://www.amazon124.com",
            "http://www.msn.com"
            };
        var tasks = urLsToProcess.Select(x => DownloadStringAsTask(new Uri(x)))
            .ToArray();
        Task.Factory.ContinueWhenAll(tasks, (Task<string>[] tasks1) =>
        {
            foreach (var task in tasks1)
            {
                //task.AsyncState will contain the Uri, add it to the textbox
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    textBox1.AppendText(string.Format("{0} : Completed", task.AsyncState));
                }
                else if (task.Status == TaskStatus.Faulted)
                {
                    textBox1.AppendText(string.Format("{0} : Faulted", task.AsyncState));
                }
                else if (task.Status == TaskStatus.Canceled)
                {
                    textBox1.AppendText(string.Format("{0} : Canceled", task.AsyncState));
                }
                textBox1.AppendText(Environment.NewLine);
            }
        }, CancellationToken.None, TaskContinuationOptions.None, uiContext);
    }
    static Task<string> DownloadStringAsTask(Uri address)
    {
        TaskCompletionSource<string> tcs =
          new TaskCompletionSource<string>(address);
        WebClient client = new WebClient();
        client.DownloadStringCompleted += (sender, args) =>
        {
            if (args.Error != null)
                tcs.SetException(args.Error);
            else if (args.Cancelled)
                tcs.SetCanceled();
            else
                tcs.SetResult(args.Result);
        };
        client.DownloadStringAsync(address);
        return tcs.Task;
    }
