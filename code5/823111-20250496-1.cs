    BackgroundWorker bg = new BackgroundWorker();
    private void button1_Click(object sender, EventArgs e)
    {
        if (bg.IsBusy) return;
        progressBar1.Value = 0;
        bg.DoWork += bg_DoWork;
        bg.ProgressChanged += bg_ProgressChanged;
        bg.RunWorkerCompleted += bg_RunWorkerCompleted;
        bg.WorkerReportsProgress = true;
        bg.RunWorkerAsync();
    }
    void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        // Alert user to completion
        txt_percent.Text = "Finished";
    }
    void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // Visual Diplay, but not updating
        txt_percent.Text = e.UserState.ToString();
        progressBar1.Value = e.ProgressPercentage;
    }
    void bg_DoWork(object sender, DoWorkEventArgs e)
    {
        //Get info for progress bar
        int total = 25;
        // Send Message to each user
        for (int x = 0; x < total; x++)
        {
            //Actual send message
            sendMail();
            bg.ReportProgress((int)Math.Round(((float)x / (float)total) * 100), "Sending Message " + x.ToString() + " of " + total.ToString());
        }
    }
    private void sendMail()
    {
        Thread.Sleep(5000);
    }
