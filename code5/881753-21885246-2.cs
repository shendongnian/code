    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        while (sw.IsRunning)
        {
            // Display elapsed time in seconds.
            processingMessageTextBox.Invoke(new MethodInvoker(delegate { processingMessageTextBox.Text = (sw.ElapsedMilliseconds / 1000).ToString(); }));
        }
    }
