        BW.WorkerReportsProgress = true;
        BW.WorkerSupportsCancellation = true;
        BW.DoWork += new DoWorkEventHandler(BW_DoWork);
        BW.ProgressChanged += new ProgressChangedEventHandler(BW_ProgressChanged);
        BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_WorkCompleted);
        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Connection Lost. Current Status Code " + Response.StatusCode);
        }
