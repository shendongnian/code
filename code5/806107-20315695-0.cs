    private void Main_Load(object sender, EventArgs e)
    {
       // Start Background Worker on load
       bgWorker.RunWorkerAsync();
    }
    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
       Thread.Sleep(1000);   // If you need to make a pause between runs
       // Do work here
    }
    private void bgCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    // Update UI
    
    // Run again
    bgWorker.RunWorkerAsync();   // This will make the BgWorker run again, and never runs before it is completed.
    }
