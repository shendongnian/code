    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        string message = DateTime.Now.ToString("T") + " - " + e.ProgressPercentage.ToString() + "% Done";
        txtboxLogger.AppendText(message + Environment.NewLine);
    }
