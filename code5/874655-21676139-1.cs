    private void bgworker1_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        for (int i = 1; i <= 100; i++)
        {
            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // Perform your operations and report progress like below.
                worker.ReportProgress(i * 1);
            }
        }
    }
