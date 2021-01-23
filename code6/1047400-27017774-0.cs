    BackgroundWorker bw = new BackgroundWorker();    
    bw.WorkerSupportsCancellation = true;    
    bw.WorkerReportsProgress = true;
    bw.DoWork += 
    new DoWorkEventHandler(bw_DoWork);
    bw.ProgressChanged += 
    new ProgressChangedEventHandler(bw_ProgressChanged);
    bw.RunWorkerCompleted += 
    new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    private void button5_Click(object sender, EventArgs e)
    {
          // rest of the code above this...
          if (bw.IsBusy != true)
          {
              bw.RunWorkerAsync();
          }
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {  
         // rest of the code above this...
         Copy(@source, @dest);
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
         progressBar1.Visible = true;
         progressBar1.Step = copied;
         progressBar1.PerformStep();
    }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
          MessageBox.Show("Completed");
    }
    
