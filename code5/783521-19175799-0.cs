    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Backgroundworker bgw = ctype(sender,backgroundworker);
            Process p = new Process();
            p.StartInfo.FileName = "d:\\fix.exe";
            p.StartInfo.Arguments = "-l";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = false;
            p.EnableRaisingEvents = true;
            p.Start();
            // report progress by calling reportprogress()
            bgw.ReportProgress('Integer value to be passed and used for the progressbar')
            p.BeginOutputReadLine();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage.ToString();
        }
    
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
    
        } 
