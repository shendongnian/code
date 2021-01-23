    private Options options = Options.All; // set your default value here
    public Options Options
    { 
        get { return options; }
        set { options = value; NotifyPropertyChanged("Options"); }
    }
