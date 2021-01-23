    private Visibility listViewVisibility;
    public Visibility ListViewVisibility
    {
        get { return listViewVisibility; }
        set
        {
            if (this.listViewVisibility == value)
                return;
            this.listViewVisibility = value;
            this.OnPropertyChanged("ListViewVisibility");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        if(this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
