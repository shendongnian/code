    void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_task.IsCompleted)
        {
            e.Cancel = true;
            _cts.Cancel();
            _task.ContinueWith(t => Close(), 
                TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
