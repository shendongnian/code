    //Create a background worker
        private System.ComponentModel.BackgroundWorker backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
    
    //Add event handler to the background worker in your main form_load event
    
    // tell the background worker it can report progress
    backgroundWorker1.WorkerReportsProgress = true;
    
    // add our event handlers
    backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
    backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(this.ProgressChanged);
    
    //This is the method to do background work. Can be in a separate class.
    backgroundWorker1.DoWork += new DoWorkEventHandler(this.ExportInExcel);
    
    
    //On button click tell the worker to start. It will call 
     backgroundWorker1.RunWorkerAsync();
    
    //In ExportInExcel update the progress when some part of work finishes
    public void ExportInExcel(object sender, EventArgs e)
    {
    BackgroundWorker worker = sender as BackgroundWorker;
    //process first step
    worker.ReportProgress(10, "Setting up the query");
    //and so on
    
    }
    
    //Progress changed from the worker
      public void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    //update progress bar
    }
    
    private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    //Work complete. Hide progress bar etc.
    }
