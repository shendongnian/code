    Window _progressWindow = new Window();
    
    AsyncOp _draw = new AsyncOp();
    
    async void Button_Click(object s, EventArgs args)
    {
        try
        {
            Task thisTask = null;
            thisTask = _draw.RunAsync(async (token) =>
            {
                var progress = new Progress<int>(
                    (i) => { /* update the progress inside progressWindow */ });
    
                // show and reset the progress
                _progressWindow.Show();
                try
                {
                    // do the long-running task
                    await this.DrawContent(this.TimePeriod, progress, token);
                }
                finally
                {
                    // if we're still the current task,
                    // hide the progress 
                    if (thisTask == _draw.PendingTask)
                        _progressWindow.Hide();
                }
            }, CancellationToken.None);
            await thisTask;
        }
        catch (Exception ex)
        {
            while (ex is AggregateException)
                ex = ex.InnerException;
            if (!(ex is OperationCanceledException))
                MessageBox.Show(ex.Message);
        }
    }
    
    class AsyncOp
    {
        Task _pendingTask = null;
        CancellationTokenSource _pendingCts = null;
    
        public Task PendingTask { get { return _pendingTask; } }
    
        public void Cancel()
        {
            if (_pendingTask != null && !_pendingTask.IsCompleted)
                _pendingCts.Cancel();
        }
    
        public Task RunAsync(Func<CancellationToken, Task> routine, CancellationToken token)
        {
            var oldTask = _pendingTask;
            var oldCts = _pendingCts;
    
            var thisCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
            Func<Task> startAsync = async () =>
            {
                // await the old task
                if (oldTask != null && !oldTask.IsCompleted)
                {
                    oldCts.Cancel();
                    try
                    {
                        await oldTask;
                    }
                    catch (Exception ex)
                    {
                        while (ex is AggregateException)
                            ex = ex.InnerException;
                        if (!(ex is OperationCanceledException))
                            throw;
                    }
                }
                // run and await this task
                await routine(thisCts.Token);
            };
    
            _pendingCts = thisCts;
    
            _pendingTask = Task.Factory.StartNew(
                startAsync,
                _pendingCts.Token,
                TaskCreationOptions.None,
                TaskScheduler.FromCurrentSynchronizationContext()).Unwrap();
    
            return _pendingTask;
        }
    }
