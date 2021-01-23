    private void OnButtonStartClick(object sender, EventArgs e)
    {
        // Start a new task
        Task<int> workerTask = Task<int>.Factory.StartNew(
            () => PerformLongRunningOperation(_ctSource.Token), _ctSource.Token);
        // when the task has finished, display the result (On the GUI Thread!)
        workerTask.ContinueWith((task) =>
        {
            if (task.IsCanceled)
            {
                MessageBox.Show("Calculation has been canceled.");
                return;
            }
            _LabelResult = task.Result;
        }, TaskScheduler.FromCurrentSynchronizationContext); // required to run this part on the GUI thread
    }
