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
         CopyLotsOfFiles() // This is the function which is being run in the background
       e.Result = true;// Tell that you are done
    }
    void CopyLotsOfFiles()
    {
      Int32 counter = 0;
      List<String> filestobeCopiedList = ...; // get List of files to be copied
      foreach (var file in filestobeCopiedList)
      {
           counter++;
          // Calculate percentage for Progress Bar
          Int32 percentage = (counter * 100) / filesCount;
          bgWorker.ReportProgress(percentage);
          // Files copy code goes here
      }
      bgWorker.ReportProgress(100);
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
      var operationSuccessFul = Convert.ToBoolean(e.Result);
      if(operationSuccessFul)
       MessageBox.Show("I am Done");
    }
