        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                Backgroundworker bgw = ctype(sender,backgroundworker);
                Process p = new Process();
                p.StartInfo.FileName = "d:\\fix.exe";
                // report progress by calling reportprogress()
                bgw.ReportProgress(2);
                p.StartInfo.Arguments = "-l";
                p.StartInfo.UseShellExecute = false;
                // report progress by calling reportprogress()
                bgw.ReportProgress(5);
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = false;
                p.EnableRaisingEvents = true;
                p.Start();
                // report progress by calling reportprogress()
                bgw.ReportProgress(7);
                p.BeginOutputReadLine();
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                progressBar1.Maximum = 10
                backgroundWorker1.RunWorkerAsync();
            }
        
            private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar1.Value = e.ProgressPercentage.ToString();
            }
        
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
        
                progressBar1.Value = 10;
            } 
