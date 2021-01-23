    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (e.ProgressPercentage == 0)
        {
            string message = DateTime.Now.ToString("T") + " - Start processing ... ";
            txtboxLogger.AppendText(message + Environment.NewLine);		            
        }
    }
