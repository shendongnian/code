    // At the class level, put this:
    BackgroundWorker bw = new BackgroundWorker();
    bw.WorkerReportsProgress = true; // This means we want to send updates from the background worker.
     
    // The DoWork method handles your time consuming task, which in this case is your download method. So you can try this:
    private void Download()
    {
	    bw.RunWorkerAsync();
    }
     
    // This should be called as a result:
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
	    // The worker who's progress will be updated.
	    BackgroundWorker worker = sender as BackgroundWorker;
	    req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
	    res = (HttpWebResponse)req.GetResponse();
	
	    Int64 contentLength = res.ContentLength;
	
	    ResponseStr = res.GetResponseStream();
	
	    strLocal = new FileStream(@"E:\xxx.tar.gz", FileMode.Create, FileAccess.Write, FileShare.None);
	    byte[] read = new byte[1024];
	
	    int readed = 0;
	    while((readed = ResponseStr.Read(read, 0, read.Length)) > 0)
	    {
		    strLocal.Write(read, 0, readed);
		    // Update the worker (this uses the number you calculated)
		    worker.ReportProgress(Convert.ToInt32((ResponseStr.Length * 100) / strLocal.Length));
		
		    strLocal.Close();
		    ResponseStr.Close();
        }
    }
     
    // This is called via worker.ReportProgress
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
	    progressBar1.Value = e.ProgressPercentage;
    }
