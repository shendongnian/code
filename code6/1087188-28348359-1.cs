            BW = new System.ComponentModel.BackgroundWorker();
            BW.WorkerReportsProgress = true;
            BW.WorkerSupportsCancellation = true;
            BW.DoWork += new System.ComponentModel.DoWorkEventHandler(BW_DoWork);
            BW.ProgressChanged += new ProgressChangedEventHandler(BW_ProgressChanged);
            BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(BW_RunWorkerCompleted);
        private static void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Current Connection Status " + Response.StatusCode);
        }
