    private bool doImport;
    public bool DoImport
    {
        get { return doImport; }
        set
        {
            doImport = value;
            this.OnPropertyChanged("DoImport");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
