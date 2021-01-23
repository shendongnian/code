    public string DoSomethingQuick()
    {
         var backgroundWorker = new BackgroundWorker() { WorkerSupportsCancellation = true };
         backgroundWorker.ReportProgress += delegate(object s, ProgressChangedEventArgs e)
         {
             DoSomethingThatTakes10MinutesAndExecutedOnUiThread();
         }
         backgroundWorker.DoWork += delegate(object s, DoWorkEventArgs e)
         {
             backgroundWorker.ReportProgress(0); // the progress value is irrelevant
         };
         backgroundWorker.RunWorkerAsync();
         return "Process Started"; 
     }
