    private double _progressLabelContent;
    
    public double ProgressLabelContent
    {
    get {return _progressLabelContent; }
    set { _progressLabelContent=value; OnPropertyChanged("ProgressLabelContent"); }
    }
 
     public void updateProgressBar()
     {
         Application.Current.Dispatcher.Invoke(delegate
         {
             ProgressValue = ((double)progressCounter * 100) / locationList.Count;
             ProgressLabelContent = ProgressValue + " / 100";
         });
    
     }  
