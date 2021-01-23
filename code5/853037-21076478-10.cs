    private bool isBusy;
    public bool IsBusy
    {
        get { return isBusy; }
        set
        {
            this.isBusy = value;
            this.OnPropertyChanged("IsBusy");
        }
    }
