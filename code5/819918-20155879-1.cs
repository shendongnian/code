    public string CleanerStatus
    {
        get { return cleanerStatus; }
        set
        {
            cleanerStatus = value;
            App.Current.Dispatcher.BeginInvoke(
                new Action(() => OnPropertyChanged("CleanerStatus")));
        }
    }
