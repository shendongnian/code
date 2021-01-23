    var cts = new CancellationTokenSource();
    pb.btnCancel.Click += (s, e) => cts.Cancel();
    pb.Show();
    var task = Task.Factory.StartNew(() => GetCases())
        .ContinueWith(t => t.Result, cts.Token)
        .ContinueWith(t =>
        {
            //TODO do whatever you want after the operation finishes or is cancelled;
            //use t.IsCanceled to see if it was canceled or not.
        });
