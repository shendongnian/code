    private BackgroundWorker _worker = null;
    private void goButton_Click(object sender, EventArgs e)
    {
        _worker = new BackgroundWorker();
        _worker.WorkerSupportsCancellation = true;
        _worker.DoWork += new DoWorkEventHandler((state, args) =>
        {
            do
            {
                if (_worker.CancellationPending)                
                    break;
                Console.WriteLine("Hello, world");
            } while (true);
        });
        _worker.RunWorkerAsync();
        goButton.Enabled = false;
        stopButton.Enabled = true;
    }
    private void stopButton_Click(object sender, EventArgs e)
    {
        stopButton.Enabled = false;
        goButton.Enabled = true;
        _worker.CancelAsync();
    }
