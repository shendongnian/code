    private void buttonCancel_Click(object sender, RoutedEventArgs e)
    {
    if (bw.WorkerSupportsCancellation == true)
    {
        bw.CancelAsync();
    }
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    BackgroundWorker worker = sender as BackgroundWorker;
    for (int i = 1; (i <= 10); i++)
    {
        if ((worker.CancellationPending == true))
        {
            e.Cancel = true;
            break;
        }
        else
        {
            // Do something heavy
        }
    }
    }
