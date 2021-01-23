    void bgw_DoWork(object sender, DoWorkEventArgs e)
     {
      //Your time taking work. Here it's your data query method.
      CheckSsMissingDate();
     }
    void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
     {
       //Progress bar.
       progressBar1.Value = e.ProgressPercentage;
     }
     void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
       //After completing the job.
       MessageBox.Show(@"Finished");
      }
