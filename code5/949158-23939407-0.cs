        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            if(workerThread.IsBusy == false)  // Make sure someone doesn't click run multiple times by mistake
            {
                pBar1.Value = 0;
                workerThread.RunWorkerAsync();
            }
        }
  
        private void workerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            // Definitions and so forth
            pBar1.Minimum = 0;
            pBar1.Maximum = length;
            int status = 0;
            using (StreamReader sr = new StreamReader(filelist))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Try/Catch work here
                    status++;
                    workerThread.ReportProgress(status);
                }
        }
        
        private void workerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar1.Value = e.ProgressPercentage;
        }
