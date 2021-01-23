    public CardState State
    {
        get { return state; }
        set
        {
            if (state != value)
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
