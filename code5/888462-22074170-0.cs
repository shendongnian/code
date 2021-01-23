    protected void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        //Do database stuff here
    }
    
    protected void bw_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //This is called when the background worker is done.  This is where you can update the UI
    }
