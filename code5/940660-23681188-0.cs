    private void ReportAction(string label, Action<BackgroundWorker> action)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerSupportsCancellation = false;
        worker.WorkerReportsProgress = true;
        worker.DoWork += new DoWorkEventHandler((object sender, DoWorkEventArgs e) =>
        {
            action(worker);
        });
        worker.ProgressChanged += new ProgressChangedEventHandler(this.OnProgressChanged);
        this.LogTextBox.AppendText(label);
        worker.RunWorkerAsync();
    }
    private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (e.ProgressPercentage % 25 == 0)
        {
            this.LogTextBox.AppendText(" .");
        }
    }
