    backgroundWorker1.DoWork += doWork;
    backgroundWorker1.ProgressChanged += progressChanged;
    private void doWork(object sender, DoWorkEventArgs e)
    {
        for (int l = 0; l < newfile.Length; l++)
        {
           vfswriter.Write(newfile[l]);
           double percentage = ((double)l / (double)newfile.Length * 100);
           var value = int.Parse(Math.Truncate(percentage).ToString());
           backgroundWorker1.ReportProgress(value);
        }
    }
    private void progressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.progressBar1.Value = e.ProgressPercentage;
    }
