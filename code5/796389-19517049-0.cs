    private void m_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (ProcessingJob job in m_processingJobs )
        {
             if (job.somethingIsWrong)
             {
                throw new Exception("It failed because...");             
             }
        }
     }
    private void m_backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
         if (e.Exception != null)
         {            
            SomethingIsWrongDialog dialog = new SomethingIsWrongDialog(); 
            dialog.showDialog();
         }
         else
         {
            Debug.WriteLine("Finished!");
            this.Close();
         } 
       
    }
