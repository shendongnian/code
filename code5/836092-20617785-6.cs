    private void ProcessButtonClickAction(object param)
    {
       BackgroundWorker BGWUpdateUi = new BackgroundWorker()
       BGWUpdateUi.DoWork += (sender, args) =>
       {
           foreach (var obj in FileList)
           {
               Thread.Sleep(250);
               obj.Status = "Completed";
               ProgressBarValue += pbvalueIncrement;
           }
       };
       BGWUpdateUi.RunWorkerAsync();
    }
