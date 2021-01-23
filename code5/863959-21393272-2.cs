    backgroundWorker1.DoWork += doWork;
    private void doWork(object sender, DoWorkEventArgs e)
    {
        for (int l = 0; l < newfile.Length; l++)
        {
           vfswriter.Write(newfile[l]);
           double percentage = ((double)l / (double)newfile.Length * 100);
           this.progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
        }
    }
