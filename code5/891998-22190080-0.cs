    private async void btnDo_Click(object sender, EventArgs e)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        // Create the ProgressForm, and hook up the cancellation to it.
        ProgressForm progressForm = new ProgressForm();
        progressForm.Cancelled += () => cts.Cancel();
        
        var dialogReadyTcs = new TaskCompletionSource<object>();
        progressForm.Load += (sX, eX) => dialogReadyTcs.TrySetResult(true);
        var dialogTask = Task.Factory.StartNew( 
            () => progressForm.ShowDialog(),
            cts.Token,
            TaskCreationOptions.None,
            TaskScheduler.FromCurrentSynchronizationContext());
        // await to make sure the dialog is ready
        await dialogReadyTcs.Task;
        // continue on a new nested message loop,
        // started by progressForm.ShowDialog()
        // Create the progress reporter - and have it update 
        //  the form directly (if form is valid (not disposed))
        Action<int> progressHandlerAction = (progressInfo) =>
        {
            if (!progressForm.IsDisposed) // don't attempt to use disposed form
                progressForm.UpdateProgress(progressInfo);
        };
        Progress<int> progress = new Progress<int>(progressHandlerAction);
        try
        {
            // await the worker task
            var taskResult = await MyService.DoSomethingWithResultAsync(100, token, progress);
            // await the dialog task, to make sure the dialog is closed
            await dialogTask;
        }
        catch (Exception ex)
        {
            while (ex is AggregateException)
                ex = ex.InnerException;
            if (!(ex is OperationCanceledException))
                MessageBox.Show(ex.Message); // report the error
        }
        if (!progressForm.IsDisposed)
            progressForm.Close();
        
        // this make sure showDialog returns and the nested message loop is over
        await dialogTask;
    }
