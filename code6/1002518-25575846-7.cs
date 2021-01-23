    private void DoWork(object sender, DoWorkEventArgs e)
    {
      for (int i = 0; i < 10; i++)
       {
        Thread.Sleep(1000);
        _Worker.ReportProgress(i*(100/10));          
      }            
    }
    private void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        _CurrentProgress = e.ProgressPercentage;
        OnPropertyChanged("CurrentProgress");
    }
