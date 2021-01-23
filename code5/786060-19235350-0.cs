    private void SomeMethod()
    {
        // Create backgroundworker
        BackgroundWorker bw = new BackgroundWorker();
        // Attach event handler
        bw.DoWork += bw_DoWork;
    
        // Run Worker
        bw.RunWorkerAsync();
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        // Do background stuff here
    }    
