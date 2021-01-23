    protected override void OnFormClosing(FormClosingEventArgs e)
    {
    e.Cancel = !mCompleted;
    base.OnFormClosing(e)
        if (!mCompleted)
        {
            backgroundWorker1.CancelAsync();
            this.Enabled = false;
            mClosePending = true;
           
        }  
      
    }
