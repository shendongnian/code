        var worker = new BackgroundWorker();
        worker.DoWork += WorkerDoWork;
        worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        worker.RunWorkerAsync();
        private static void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            throw new Exception("my exception");
        }
    
        private static void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //error handling
            }
        }
