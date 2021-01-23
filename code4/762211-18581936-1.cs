    //declare in form
    var bw = new BackgroundWorker();
    //in constructor or load write this
    bw.WorkerReportsProgress = true;
    bw.DoWork += new DoWorkEventHandler(bwDoWork);
    bw.ProgressChanged += new ProgressChangedEventHandler(bwProgressChanged);
    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwCompleted);
    private void bwDoWork(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;
        for(int i = 0; i < 50; i++)
        {
            for(int e = 0; e < 50; e++)
            {
                for(int a : 0; a < 50; a++)
                {
                    worker.ReportProgress(a * e * i);
                }
            }  
        }
    }
    private void bwProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        var pp=e.ProgressPercentage; //now set the progress here
    }
    private void bwCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //set the progress to 100% etc.
    }
