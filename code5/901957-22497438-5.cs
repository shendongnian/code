    private void startButton_Click(object sender, EventArgs e)
    {
        // update the UI
        this.startButton.Enabled = false;
        this.stopButton.Enabled = true;
        Action enableUI = () =>
        {
            // update the UI
            this.startButton.Enabled = true;
            this.stopButton.Enabled = false;
            this._cancelWork = null;
        };
        Action<Exception> handleError = (ex) =>
        {
            // error reporting
            MessageBox.Show(ex.Message);
        };
        try
        {
            // prepare to handle cancellation
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            this._cancelWork = () =>
            {
                this.stopButton.Enabled = false;
                cts.Cancel();
            };
            var data = _data.ToArray();
            var total = data.Length;
            // prepare the progress updates
            this.progressBar.Value = 0;
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = total;
            var progressReport = new Progress<int>((i) =>
            {
                this.progressBar.Increment(1);
            });
            // offload Parallel.For from the UI thread 
            // as a long-running operation
            var task = Task.Factory.StartNew(() =>
            {
                Parallel.For(0, total, (item, loopState) =>
                    DoWorkItem(data, item, token, progressReport, loopState));
                // observe cancellation
                token.ThrowIfCancellationRequested();
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            task.ContinueWith(_ => 
            {
                try
                {
                    task.Wait(); // re-throw any error
                }
                catch (Exception ex)
                {
                    while (ex is AggregateException && ex.InnerException != null)
                        ex = ex.InnerException;
                    handleError(ex);
                }
                enableUI();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        catch (Exception ex)
        {
            handleError(ex);
            enableUI();
        }
    }
