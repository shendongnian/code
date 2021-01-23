    BackgroundWorker bgWorker = new BackgroundWorker();
    bgWorker.DoWork += BackgroundWorkerDoWork;
    bgWorker.ProgressChanged += BackgroundWorkerProgressChanged;
    bgWorker.RunWorkerCompleted += new BackgroundWorkerCompletedEventHandler
					(bgWorker_RunWorkerCompleted);
     void StartWork()
     { 
      // Start BackGround Worker Thread 
       bgWorker.RunWorkerAsync();
     }
     void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
     {
            //NOTE : DONT play with the UI thread here...
           // Do Whatever work you are doing and for which you need to show    progress bar
      }
       void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
       {
         // Access Main UI Thread here
          progressBar1.Value = e.ProgressPercentage;
       }
        private void BackgroundWorkerCompletedEventHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            //Always check e.Cancelled and e.Error before checking e.Result!
            //even though I'm skipping that here
           MessageBox.Show("I am Done");
        }
