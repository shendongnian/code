    private void buttonGo_Click(object sender, EventArgs e)
            {
                myrow = p.FetchNext();
                this.dt = p.dt.Copy();
                bs.DataSource = dt;
                dataGridViewMyData.DataSource = bs;
                bs.ResetBindings(false);
                if (!p.isEnded && !backgroundWorker1.IsBusy )
                {
                    bs.SuspendBinding();
                    backgroundWorker1.RunWorkerAsync();
                }
             }
  
      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bs.SuspendBinding();
            if (!p.isEnded)
            {
                dt.ImportRow(p.FetchNext());
            }
            
        }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        bs.ResumeBinding();
        if (!p.isEnded)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        else
        {
            
            MessageBox.Show("Done");
        }
        RefreshData();
        
    }
