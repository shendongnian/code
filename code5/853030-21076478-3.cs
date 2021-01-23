    private int progressValue ;
    public int ProgressValue 
    {
        get { return progressValue ; }
        set
        {
            this.progressValue =value;
            this.OnPropertyChanged("ProgressValue ");
        }
    }
