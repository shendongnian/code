    public void LoadSomething()
    {
     LoadWindow loading = new LoadWindow();
     loading.Show();
     loading.BringToFront();
     
     BackgroundWorker worker = new BackgroundWorker();
     worker.DoWork += new DoWorkEventHandler(worker_DoWork);
     worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
     worker.RunWorkerAsync(loading)
    }
    
    private void worker_DoWork(object sender, DoWorkEventArgs e)
    {
     // Do your background-work here
     Thread.Sleep(10000);
     e.Result = e.Argument;
    }
    
    private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
     LoadWindow loading= (LoadWindow)e.Result;
     loading.Close();
    }
     
     
