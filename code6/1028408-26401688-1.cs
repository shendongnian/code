    BackgroundWorker worker = new BackgroundWorker();
    worker.DoWork += (worker, result) =>
    {
    	int progress = 0;
    
    	//DTRowCount CANNOT be anything UI based here
    	// this thread cannot interact with the UI
        if (DTRowCount > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
            	progress = i;
                
                -----
                ---- //do some operation, DO NOT INTERACT WITH THE UI
                -----
    
                (worker as BackgroundWorker).ReportProgress(progress); 
            }
         }
    };
    
    worker.ProgressChanged += (s,e) => 
    {
    	//here we can update the UI
    	progressBar1.Value = e.ProgressPercentage
    };
    worker.RunWorkerCompleted += (s, e) =>
    {
    	MessageBox.Show("Task completed");
                            progressBar1.Visible = false;
    };
    
    worker.RunWorkAsync();
