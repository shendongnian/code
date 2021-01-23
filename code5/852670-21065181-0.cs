    public Person ActualPerson
    {
        get { return this.actualPerson; }
        set
        {
            if (this.actualPerson == value)
                return;
            this.actualPerson = value;
            this.OnPropertyChanged("ActualPerson");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        if (this.PropertyChanged != null)
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
